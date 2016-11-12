using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Newtonsoft.Json;
using System.Data.SqlClient;
using System.IO;
using System.Web.Script.Serialization;

namespace WCFServiceWebRole
{
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.

    //without this attribute service doesn't work this is service added manually to project
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class NotesService : INotesService
    {
    
        serverResponse INotesService.addnote(string userid, string note)
        {

            //MemoryStream stream1 = new MemoryStream();
            //stream1.Position = 0;
            //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NotesData));
            //var results = (NotesData)ser.ReadObject(stream1);

            JavaScriptSerializer j = new JavaScriptSerializer();
            NotesData results = (NotesData)j.Deserialize(note, typeof(NotesData));


            serverResponse sr = new serverResponse();
            try
            {
                
                using (var entities = new NotesDbEntities())
                {
                    entities.NotesDatas.Add(results);
                    entities.SaveChanges();

                    sr.Status = "OK";
                    sr.note.GuidID = results.GuidID;
                    sr.note.UserID = userid;
                    sr.note.Createdate = results.Createdate;
                    sr.note.Notes = results.Notes;
                    sr.note.UpdateDate = results.UpdateDate;


                }
                return sr;
            }
            catch (Exception ex)
            {
                sr.Status = "ERROR";
                return sr;
            }
        }

        bool INotesService.deletenote(string note)
        {
            
            return true;
        }

        bool INotesService.updatenote( string note)
        {
            throw new NotImplementedException();
        }
       
        NotesData[] INotesService.GetNotes(string userid)
        {
            if (userid == "") userid = "test11@test.com";
            using (var entities = new NotesDbEntities())
            {
                return entities.NotesDatas.Where(x => x.UserID == userid).ToArray();
            }

        }

        NotesData[] INotesService.GetNote(string note)
        {
           
            using (var entities = new NotesDbEntities())
            {
                return entities.NotesDatas.Where(x => x.GuidID == new Guid(note)).ToArray();
            }

        }


        NotesData[] INotesService.GetSingNotes(string userid, string note)
        {
            if (userid == "") userid = "test11@test.com";
            using (var entities = new NotesDbEntities())
            {
                return entities.NotesDatas.Where(x => x.UserID == userid && x.GuidID==new Guid(note)).ToArray();
            }

        }
        string GetSingNotesold(string userid, string note)
        {

            if (string.IsNullOrEmpty(userid) || string.IsNullOrEmpty(note)) return "[invalid input]";

            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();

            var jsonResult = new StringBuilder();
            using (var connection = new SqlConnection(
                    "Data Source = tcp:syncdbserver.database.windows.net,1433; Initial Catalog = appDB; User Id = jazzyg@syncdbserver.database.windows.net; Password = Azured3mon@12; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {
                string sql = @"select [UserID] as [note.userid],[GuidID] as [note.guidid],[Notes] as [note.notetext],
                                [UpdateDate] as [note.updatedate] 
                                from [dbo].[NotesData] 
                                where userid=@userid 
                                and GuidID = @note
                                FOR JSON PATH, ROOT('Notes')";


                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                cmd.Parameters.AddWithValue("@note", note);
                connection.Open();

                //IList<string> storeNames = o.SelectToken("Stores").Select(s => (string)s).ToList();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }

                    connection.Close();
                }

            }
            return jsonResult.ToString();

        }
        string GetNotesold(string userid)
        {
            if (userid == "") userid = "test11@test.com";
            //var con = ConfigurationManager.ConnectionStrings["Yourconnection"].ToString();
            List<NotesData> notes;
            var jsonResult = new StringBuilder();
            using (var connection = new SqlConnection(
                    "Data Source = tcp:syncdbserver.database.windows.net,1433; Initial Catalog = appDB; User Id = jazzyg@syncdbserver.database.windows.net; Password = Azured3mon@12; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30;"))
            {
                string sql = @"select [UserID] as [note.userid],[GuidID] as [note.guidid],[Notes] as [note.notetext],
                                [UpdateDate] as [note.updatedate] 
                                from [dbo].[NotesData] 
                                where userid=@userid FOR JSON PATH, ROOT('Notes')";


                SqlCommand cmd = new SqlCommand(sql, connection);
                cmd.Parameters.AddWithValue("@userid", userid);
                connection.Open();

                //IList<string> storeNames = o.SelectToken("Stores").Select(s => (string)s).ToList();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (!reader.HasRows)
                    {
                        jsonResult.Append("[]");
                    }
                    else
                    {
                        while (reader.Read())
                        {
                            jsonResult.Append(reader.GetValue(0).ToString());
                        }
                    }
                    //notes = new List<NotesData>();
                    //while (oReader.Read())
                    //{
                        //NotesData n = new NotesData();
                        //n.UserID = oReader["UserID"].ToString();
                        //n.GuidID = (Guid)oReader["GuidID"];
                        //n.Notes = oReader["Notes"].ToString();
                        //n.Createdate = (DateTime)oReader["Createdate"];
                        //n.UpdateDate = (DateTime)oReader["UpdateDate"];

                        //notes.Add(n);
                    //}

                    connection.Close();
                }
                //NotesData n = new NotesData();
                //MemoryStream stream1 = new MemoryStream();
                //DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NotesData));
                //ser.WriteObject(stream1, n);
            }
            return jsonResult.ToString();
        }

    }
}

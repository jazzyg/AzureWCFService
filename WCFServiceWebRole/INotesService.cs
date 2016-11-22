using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCFServiceWebRole
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract(Namespace="IRestService/JSONData")]
    public interface INotesService
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "getnotes/{userid}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        NotesData[] GetNotes(string userid);

        [OperationContract]
        [WebInvoke(UriTemplate = "getnote/{note}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        //NotesData GetSingNotes(string userid, string note);
        NotesData[] GetNote(string note);


        [OperationContract]
        [WebInvoke(UriTemplate = "getsingnotes/{userid}/{note}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        //NotesData GetSingNotes(string userid, string note);
        NotesData[] GetSingNotes(string userid, string note);


        [OperationContract]
        [WebInvoke(UriTemplate = "addnote/{userid}/{note}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        serverResponse addnote(string userid, string note);

        [OperationContract]
        [WebInvoke(UriTemplate = "deletenote/{note}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool deletenote(string note);

        [OperationContract]
        [WebInvoke(UriTemplate = "updatenote/{note}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool updatenote(string note);

        [OperationContract(IsInitiating = true, IsTerminating = false)]
        void login(string username, string password);

        
        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);


    }



}

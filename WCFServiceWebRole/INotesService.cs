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
        //string GetNotes(string userid);

        [OperationContract]
        [WebInvoke(UriTemplate = "getsingnotes/{userid}/{note}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        //NotesData GetSingNotes(string userid, string note);
        string GetSingNotes(string userid, string note);


        [OperationContract]
        [WebInvoke(UriTemplate = "addnote/{userid}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        string addnote(NotesData note);

        [OperationContract]
        [WebInvoke(UriTemplate = "deletenote/{userid}/{note}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool deletenote(string userid, string note);

        [OperationContract]
        [WebInvoke(UriTemplate = "updatenote/{userid}/{note}",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool updatenote(NotesData note);

        [OperationContract]
        [WebInvoke(UriTemplate = "getContactNotes/{userid}",
            Method = "GET",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Wrapped)]
        List<ContactData> getContactNotes(string userid);

        [OperationContract]
        [WebInvoke(UriTemplate = "getSingContactNote/{userid}/{note}",
           Method = "GET",
           RequestFormat = WebMessageFormat.Json,
           ResponseFormat = WebMessageFormat.Json,
           BodyStyle = WebMessageBodyStyle.Wrapped)]
        ContactData getSingContactNote(string userid, string note);

        [OperationContract]
        [WebInvoke(UriTemplate = "addContactNote",
                    Method = "POST",
                    RequestFormat = WebMessageFormat.Json,
                    ResponseFormat = WebMessageFormat.Json,
                    BodyStyle = WebMessageBodyStyle.Wrapped)]
        bool addContactNote(ContactData note);

        //[OperationContract]
        //string GetData(int value);

        //[OperationContract]
        //CompositeType GetDataUsingDataContract(CompositeType composite);

       
    }



}

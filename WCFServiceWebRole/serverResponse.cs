using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;


namespace WCFServiceWebRole
{
    [DataContract]
    public class serverResponse
    {
        public string Status;
        public NotesData note { get; set; }
    }
}
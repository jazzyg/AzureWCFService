using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceWebRole
{
    [DataContract]
    public partial class ContactData
    {
        public int noteId { get; set; }
        public string loginuser { get; set; }
        public string Notes { get; set; }
        public Nullable<System.DateTime> UpdateDate { get; set; }
    }
}
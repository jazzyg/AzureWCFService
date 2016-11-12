using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace WCFServiceWebRole
{
    [DataContract]
    public class UserData
    {
        private long m_UserID;       //ID of the user
        private string m_UserName;     //name of the user
        private string m_UserPassword; //user's password
        private string m_UserCell;     //user's cell phone number
        private string m_UserMail;     //user's mail

        /// &lt;summary>
        /// ID of the user
        /// &lt;/summary>
        [DataMember]
        public long UserID
        {
            get { return m_UserID; }
            set { m_UserID = value; }
        }
        /// &lt;summary>
        /// name of the user
        /// &lt;/summary>
        [DataMember]
        public string UserName
        {
            get { return m_UserName; }
            set { m_UserName = value; }
        }
        /// &lt;summary>
        /// user's password
        /// &lt;/summary>
        [DataMember]
        public string UserPassword
        {
            get { return m_UserPassword; }
            set { m_UserPassword = value; }
        }
        /// &lt;summary>
        /// user's cell phone number
        /// &lt;/summary>
        [DataMember]
        public string UserCell
        {
            get { return m_UserCell; }
            set { m_UserCell = value; }
        }
        /// &lt;summary>
        /// user's mail
        /// &lt;/summary>
        [DataMember]
        public string UserMail
        {
            get { return m_UserMail; }
            set { m_UserMail = value; }
        }
    }
}
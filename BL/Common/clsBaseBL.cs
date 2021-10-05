using BL.AuthenticationAndSession;
using CommonEntity;
using Newtonsoft.Json;
using System;

namespace BL.Common
{
    abstract public class ClsBaseBL
    {
        [JsonIgnore]
        public int CompanyID
        {
            get
            {
                return ClsSessionKeys.CompanyKey;
            }

        }
        [JsonIgnore]
        public int UserID
        {
            get
            {
                return ClsSessionKeys.UserID;
            }

        }

        [JsonIgnore]
        public enAction Action { get; set; }


        public static String SetMessageFromatLI(string msg)
        {
            return String.Format("<li>{0}</li>", msg);
        }

    }
}

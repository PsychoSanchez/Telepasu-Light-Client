using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.UserActions
{
    public class AuthAction : IAction
    {
        public string Tag { get; set; }
        public string _user { get; set; }
        public string _secret { get; set; }
        public AuthAction(string guid, string user, string secret)
        {
            Tag = "AsteriskAction";
            _user = user;
            _secret = secret;
            Action = "AuthAction";
            Guid = guid;
        }
    }
}

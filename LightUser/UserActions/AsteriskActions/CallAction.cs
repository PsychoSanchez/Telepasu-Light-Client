using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.UserActions.AsteriskActions
{
    public class CallAction : IAction
    {
        private string Number;
        private string Exten;

        public CallAction(string guid, string number, string exten)
        {
            Guid = guid;
            Action = "AsteriskCall";
            Number = number;
            Exten = exten;
        }
    }
}

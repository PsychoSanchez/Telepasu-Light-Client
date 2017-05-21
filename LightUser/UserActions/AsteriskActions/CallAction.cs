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

        public CallAction(string guid, string number)
        {
            Guid = guid;
            Action = "AsteriskCall";
            Number = number;
        }
    }
}

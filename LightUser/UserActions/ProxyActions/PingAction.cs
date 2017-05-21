using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.UserActions.ProxyActions
{
    public sealed class PingAction : IAction
    {
        public long Timestamp;

        public PingAction()
        {
            Action = "Ping";
            Timestamp = DateTimeOffset.Now.ToUnixTimeSeconds();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.Events.EventArgs
{
    public class ConnectEventArgs : AuthEvent
    {
        public bool Connected = true;
        public string Message = string.Empty;

        public ConnectEventArgs(bool connected, string message)
        {
            Connected = connected;
            Message = message;
        }
    }
}

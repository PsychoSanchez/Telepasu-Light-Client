using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.Events.EventArgs
{
    public class AuthEventArgs : System.EventArgs
    {
        public AuthEvent AuthResponse;

        public AuthEventArgs(AuthEvent authEvent)
        {
            AuthResponse = authEvent;
        }
    }
}

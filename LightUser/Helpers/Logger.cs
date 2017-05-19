using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.Helpers
{
    public static class Logger
    {
        public static void Log(string message)
        {
            //byte[] byte_message = Encoding.ASCII.GetBytes(message);
            //fs.Write(byte_message, (int)fs.Length, byte_message.Length);
            File.AppendAllText("log.txt", message);
        }
    }
}

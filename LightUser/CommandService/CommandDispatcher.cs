using LightUser.Helpers;
using LightUser.UserActions;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.CommandService
{
    public class CommandDispatcher
    {
        private static TcpClient tcpClient = new TcpClient();
        private static NetworkStream stream;
        public static event EventHandler<EventArgs> ConnectSucceded;
        public static string Guid;
        public static bool ConnectToProxy()
        {
            try
            {
                tcpClient.Connect("127.0.0.1", 5000);

                if(tcpClient.Connected)
                {
                    stream = tcpClient.GetStream();   
                }

                RunPostThread();
                ConnectSucceded?.Invoke(null, new EventArgs());
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to connect to proxy#\r\n");
                Logger.Log(ex.Message+"\r\n\r\n");
                return false;
            }

            return true;
        }

        public static void SendAuthMessage(string guid, string user, string secret)
        {
            AuthAction action = new AuthAction(guid, user, secret); 

            var bytes = Encoding.ASCII.GetBytes(action.JSONConvert());
            stream.Write(bytes, 0, bytes.Length);
        }

        async private static void RunPostThread()
        {
            await Task.Run(() => PostMessage());
        }

        public static bool get_guid = false;
        private static void PostMessage()
        {
            byte[] bytes = new byte[10000];
            int i = 0;

            while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
            {
                string message = Encoding.ASCII.GetString(bytes, 0, i);
                Console.WriteLine(message);
                //if (message.Contains("Guid: "))
                //{
                //    SendAuthMessage(message.Replace("Guid: ", ""), "hjok123", "asterisk");
                //}
                if (!get_guid)
                {
                    Guid = message;
                    SendAuthMessage(message, "hjok123", "asterisk");
                    get_guid = true;
                }
            }
        }
    }
}

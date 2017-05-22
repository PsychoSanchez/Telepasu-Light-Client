using LightUser.Helpers;
using LightUser.UserActions;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using LightUser.Events;
using LightUser.Events.EventArgs;
using LightUser.UserActions.AsteriskActions;
using LightUser.UserActions.DBActions;
using LightUser.UserActions.ProxyActions;
using Newtonsoft.Json;
using Timer = System.Timers.Timer;

namespace LightUser.CommandService
{
    public class CommandDispatcher
    {
        private static readonly TcpClient TcpClient = new TcpClient();
        private static NetworkStream stream;
        public static event EventHandler<ConnectEventArgs> ConnectSucceded;
        public static event EventHandler<AuthEventArgs> OnAuthOver;
        public static event EventHandler<GetContactsEventArgs> ContactsLoaded;
        public static event EventHandler<EventArgs> Disconnected; 
        public static string Guid;
        public static string Exten = "101";
        public static bool ConnectToProxy()
        {
            try
            {
                TcpClient.Connect("127.0.0.1", 5000);

                if(TcpClient.Connected)
                {
                    stream = TcpClient.GetStream();   
                }

                RunPostThread();
                ConnectSucceded?.Invoke(null, new ConnectEventArgs(true, "OK"));
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to connect to proxy#\r\n");
                Logger.Log(ex.Message+"\r\n\r\n");
                ConnectSucceded?.Invoke(null, new ConnectEventArgs(false, "Unreachable"));
                return false;
            }
        }

        public static void SendAuthMessage(string guid, string user, string secret)
        {
            AuthAction action = new AuthAction(guid, user, secret); 

            var bytes = Encoding.ASCII.GetBytes(action.JsonConvert());
            stream.Write(bytes, 0, bytes.Length);
        }

        public static void SendAuthMessage(string user, string secret)
        {
            AuthAction action = new AuthAction(user, secret);

            var bytes = Encoding.ASCII.GetBytes(action.ToString());
            stream.Write(bytes, 0, bytes.Length);
        }

        private static async void RunPostThread()
        {
            await Task.Run(() => PostMessage());
        }

        public static bool GetGuid = false;
        private static Timer _timer;

        private static void PostMessage()
        {
            var bytes = new byte[10000];
            int i;

            try
            {
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                {
                    var message = Encoding.ASCII.GetString(bytes, 0, i);
                    Console.WriteLine(message);

                    var responseType = Parser.GetJsonValue(message, "Action");

                    switch (responseType)
                    {
                        case "Login":
                            var loginResponse = JsonConvert.DeserializeObject<AuthEvent>(message);

                            SendPingAction();
                            OnAuthOver?.Invoke(null, new AuthEventArgs(loginResponse));
                            _timer = new Timer(5000);
                            _timer.Elapsed += TimerOnElapsed;
                            _timer.AutoReset = true;
                            _timer.Enabled = true;
                            break;
                        case "DBGetContactsResponse":
                            var response = JsonConvert.DeserializeObject<GetContactsEventArgs>(message);
                            ContactsLoaded?.Invoke(null, response);
                            break;
                        default:
                            Logger.Log("#Unknown response type: " + message + "\r\n\r\n");
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to read socket stream\r\n");
                Logger.Log(ex.Message+"\r\n\r\n");
                Disconnected?.Invoke(null, new EventArgs());
            }

        }

        private static void TimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            SendPingAction();
        }

        public static void SendPingAction()
        {
            PingAction action = new PingAction();

            var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(action));
            stream.Write(bytes, 0, bytes.Length);
        }

        public static bool GetContacts()
        {
            try
            {
                GetContactsAction action = new GetContactsAction();

                var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(action));
                stream.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to get contacts book#\r\n");
                Logger.Log(ex.Message+"\r\n\r\n");
                return false;
            }
        }

        public static bool GetContacts(string filter, string filterValue)
        {
            Thread.Sleep(50);
            try
            {
                GetContactsAction action = new GetContactsAction(filter, filterValue);

                var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(action));
                stream.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to get contacts book#\r\n");
                Logger.Log(ex.Message + "\r\n\r\n");
                return false;
            }
        }

        public static bool Call(string s)
        {
            try
            {
                CallAction action= new CallAction("123", s, Exten);

                var bytes = Encoding.ASCII.GetBytes(JsonConvert.SerializeObject(action));
                stream.Write(bytes, 0, bytes.Length);
                return true;
            }
            catch (Exception ex)
            {
                Logger.Log("#Unable to call #"+s+"\r\n");
                Logger.Log(ex.Message + "\r\n\r\n");
                return false;
            }
        }
    }
}

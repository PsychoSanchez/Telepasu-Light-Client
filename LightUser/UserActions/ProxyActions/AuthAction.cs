namespace LightUser.UserActions
{
    public sealed class AuthAction : IAction
    {
        public string Tag { get; set; }
        public string User { get; set; }
        public string Secret { get; set; }
        public string Type { get; set; }
        public AuthAction(string guid, string user, string secret)
        {
            Type = "Light";
            Tag = "AsteriskAction";
            User = user;
            Secret = secret;
            Action = "Login";
            Guid = guid;
        }
        public AuthAction(string user, string secret)
        {
            Type = "Light";
            Tag = "AsteriskAction";
            User = user;
            Secret = secret;
            Action = "Login";
            Guid = null;
        }

        public override string ToString()
        {
            var message = string.Empty;

            message += "Action: " + Action + "\r\n";
            message += "Username: " + User + "\r\n";
            message += "Secret: " + Secret + "\r\n";
            message += "Type: " + Type + "\r\n";

            return message;
        }
    }
}

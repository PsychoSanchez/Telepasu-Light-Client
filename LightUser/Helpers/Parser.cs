using System;

namespace LightUser.Helpers
{
    public static class Parser
    {
        public static string GetJsonValue(string msg, string parameter)
        {
            var msgLower = msg.ToLower();
            if (!msg.Contains(parameter) && !msgLower.Contains(parameter.ToLower()))
            {
                return string.Empty;
            }

            var index = msgLower.IndexOf(parameter.ToLower(), StringComparison.Ordinal);
            var message = msg.Substring(index);

            int startPos = (parameter + "\":\"").Length;
            int endPos = message.IndexOf("\",", StringComparison.Ordinal);
            if (endPos == -1)
            {
                endPos = message.IndexOf("\"}", StringComparison.Ordinal);
            }
            int length = endPos - startPos;
            message = message.Substring(startPos, length);

            return !string.IsNullOrEmpty(message) ? message : string.Empty;
        }
    }
}

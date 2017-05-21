namespace LightUser.Events
{
    public class AuthEvent
    {
        public string Response = "Login";
        /// <summary>
        /// 200 - Ok
        /// 404 - User Not Found
        /// 401 - Login or Password incorrect
        /// </summary>
        public int Status = 200;
        public string Message = "Telepasu Proxy 2.0. Welcome and Have a nice day";
    }
}

namespace LightUser.UserActions
{
    public abstract class IAction
    {
        public virtual string Action { get; set; }
        public virtual string Guid { get; set; }

        public string JsonConvert()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}

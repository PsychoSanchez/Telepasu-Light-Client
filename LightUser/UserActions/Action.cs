using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightUser.UserActions
{
    public abstract class IAction
    {
        public virtual string Action { get; set; }
        public virtual string Guid { get; set; }

        public string JSONConvert()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}

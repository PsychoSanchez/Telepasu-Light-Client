using System;
using System.Collections.Generic;

namespace LightUser.Data
{
    public enum ClientStatus
    {
        Online = 0,
        Calling = 1,
        Talk = 2,
        Busy = 3,
        Unknown = 4,
        Unreacheble = 5,
        Hold = 6
    }
    public class Contact : ICloneable //Класс для хранения информации о клиентах
    {
        public Guid Id;
        public List<string> Number;
        public List<string> Name;
        public List<string> Organisation;
        public List<string> Position;
        public List<string> Email;
        public List<string> Site;
        public List<string> Note;
        public List<DateTime> Birthday;
        public bool OnBlf;
        public int OnBlFposition;

        private string _status = string.Empty;
        public string Status
        {
            get
            {
                return _status;
            }
            set
            {
                _status = value;
                if (_status.Contains("OK"))
                {
                    BlfStatus = ClientStatus.Online;
                }
                else if (_status.Contains("Call"))
                {
                    BlfStatus = ClientStatus.Calling;
                }
                else if (_status.Contains("Talk"))
                {
                    BlfStatus = ClientStatus.Talk;
                }
                else if (_status.Contains("Busy"))
                {
                    BlfStatus = ClientStatus.Busy;
                }
                else if (_status.Contains("Unreacheble"))
                {
                    BlfStatus = ClientStatus.Unreacheble;
                }
                else if (_status.Contains("Hold"))
                {
                    BlfStatus = ClientStatus.Hold;
                }
                else
                {
                    BlfStatus = ClientStatus.Unknown;
                }
            }
        }

        public ClientStatus BlfStatus { get; set; }

        public override string ToString()
        {
            if (Name.Count > 0)
            {
                return Name[0] + " " + Number[0];
            }
            else
                return Number[0];
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        public Contact()
        {
            Id = Guid.NewGuid();
            OnBlFposition = -1;
            Number = new List<string>();
            Name = new List<string>();
            Organisation = new List<string>();
            Position = new List<string>();
            Email = new List<string>();
            Note = new List<string>();
            Site = new List<string>();
            Birthday = new List<DateTime> {DateTime.Today};
            OnBlf = false;
            Status = string.Empty;
            BlfStatus = ClientStatus.Unknown;
        }

        public string JsonConvert()
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(this);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LightUser.Data;

namespace LightUser.Events.EventArgs
{
    public class GetContactsEventArgs : AuthEvent
    {
        public List<Contact> ContactList = new List<Contact>();

        public GetContactsEventArgs(List<Contact> contactList)
        {
            Response = "DBGetContactsResponse";
            contactList.CopyTo(ContactList.ToArray());
        }
    }
}

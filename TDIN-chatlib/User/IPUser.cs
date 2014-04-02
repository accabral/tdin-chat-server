using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public class IPUser : User
    {
        private IPAddress _address;


        public IPUser(string username, string name, IPAddress address)
            : base(username, name)
        {
            this._address = address;
        }


        public IPUser(string username, string name)
            : this(username, name, null)
        {
        }


        public IPAddress IPAddress
        {
            get { return this._address; }
        }


    }
}

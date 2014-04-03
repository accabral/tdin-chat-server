using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public class User : MarshalByRefObject
    {
        private string _user = null;
        private string _name = null;


        public User(string username, string name)
        {
            this._user = username;
            this._name = name;
        }

        public string Username
        {
            get { return this._user; }
            set { this._user = value; }
        }


        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }


    }
}

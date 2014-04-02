using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public class LoginUser : User
    {
        private string _pass;


        public LoginUser(string username, string name, string pass )
            : base(username, name)
        {
            this._pass = pass;
        }


        public LoginUser(string username, string pass)
            : this(username, null, pass)
        {
        }


        public string Pass
        {
            set { this._pass = value; }
        }





        public bool comparePassword(string password)
        {
            return this._pass == password;
        }
    }
}

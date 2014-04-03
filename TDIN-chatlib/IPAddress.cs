using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public class IPAddress : MarshalByRefObject
    {
        private string _ip = null;
        private int _port = -1;

        public IPAddress(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }

        public string IP
        {
            get { return _ip; }
        }

        public int PORT
        {
            get { return _port; }
        }
        
    }
}

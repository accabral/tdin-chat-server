using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Net;
using System.Net.Sockets;


namespace TDIN_chatserver
{
    class Program
    {
        static void Main(string[] args)
        {
            new ChatServer();
            
        }

        
    }
}

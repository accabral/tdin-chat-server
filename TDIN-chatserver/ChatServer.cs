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
    class ChatServer : TDIN_chatlib.ChatSeverInterface
    {

        private IList<TDIN_chatlib.IPUser> activeClients;
        // Redudant... The string is the same as inside de UserSession class. 
        // The users are also in the activeclients IList.
        private Dictionary<string, TDIN_chatlib.UserSession> sessions = new Dictionary<string,TDIN_chatlib.UserSession>();

        public ChatServer()
        {
            registerServer();
        }

        /// <summary>
        /// Starts the server and registers it.
        /// </summary>
        private static void registerServer()
        {
            IDictionary props = new Hashtable();
            props["port"] = 0;

            BinaryServerFormatterSinkProvider serverProvider = new BinaryServerFormatterSinkProvider();
            serverProvider.TypeFilterLevel = System.Runtime.Serialization.Formatters.TypeFilterLevel.Full;
            BinaryClientFormatterSinkProvider clientProvider = new BinaryClientFormatterSinkProvider();
            TcpChannel chan = new TcpChannel(props, clientProvider, serverProvider);  // instantiate the channel
            ChannelServices.RegisterChannel(chan, false);                             // register the channel

            ChannelDataStore data = (ChannelDataStore)chan.ChannelData;

            IPHostEntry IPHost = Dns.GetHostEntry(Dns.GetHostName());
            string _ip = "127.0.0.1";


            foreach (IPAddress ip in IPHost.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    _ip = ip.ToString();
                    // yep, dont stop and grab the last one on the list
                }
            }

            TDIN_chatlib.IPAddress localAddress = new TDIN_chatlib.IPAddress(
                                _ip, // get IP
                                new Uri(data.ChannelUris[0]).Port  // get the port
                            );

            Console.WriteLine("a: " + localAddress.IP + ", p: " + localAddress.PORT);

            Console.WriteLine("* Registering Server Object");
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(Program),
                           TDIN_chatlib.Constants.SERVER_SERVICE,
                           WellKnownObjectMode.Singleton);

            System.Console.ReadLine();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<TDIN_chatlib.IPUser> getActiveClients()
        {
            return this.activeClients;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="address"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public TDIN_chatlib.UserSession registerClient(TDIN_chatlib.IPAddress address, TDIN_chatlib.LoginUser user)
        {
            //TODO: Complete according with the interface specification.
            // Create user and add it to active users.
            TDIN_chatlib.IPUser new_user = new TDIN_chatlib.IPUser(user.Username, user.Name);
            activeClients.Add(new_user);
            // Build a session and return it.
            TDIN_chatlib.UserSession session = new TDIN_chatlib.UserSession(user.Username, user.Name);
            sessions.Add(session.SessionHash, session);
            return session;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public TDIN_chatlib.User queryUser(string username)
        {
            System.Console.WriteLine("buh");
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="hashCode"></param>
        public void disconnectClient(string hashCode)
        {
            System.Console.WriteLine("buh");
        }
    }
}

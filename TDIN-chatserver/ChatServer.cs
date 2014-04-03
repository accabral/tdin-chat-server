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
using System.Security.Cryptography;

namespace TDIN_chatserver
{
    class ChatServer : MarshalByRefObject, TDIN_chatlib.ChatSeverInterface
    {

        //private IList<TDIN_chatlib.IPUser> activeClients = new List<TDIN_chatlib.IPUser>();
        // Redudant... The string is the same as inside de UserSession class. 
        // The users are also in the activeclients IList.
        private Dictionary<string, TDIN_chatlib.IPUser> sessions = new Dictionary<string, TDIN_chatlib.IPUser>();
        private IList<TDIN_chatlib.IPUser> _tempIPList = null;

        public ChatServer()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public IList<TDIN_chatlib.IPUser> getActiveClients()
        {
            // build temporary list with all active clients, preventing this list from being repetitively built on every query
            if( _tempIPList == null )
                _tempIPList = new List<TDIN_chatlib.IPUser>(this.sessions.Values);

            return _tempIPList;
        }


        private string generateRandomHash()
        {
            byte[] bytes = new byte[16],
                   byteOut;
            string hash = String.Empty;

            using (var rng = new RNGCryptoServiceProvider())
            {
                rng.GetBytes(bytes);
            }

            using (var crypt = new SHA256Managed())
            {
                byteOut = crypt.ComputeHash(bytes);
            }

            foreach (byte bit in byteOut)
            {
                hash += bit.ToString("x2");
            }

            return hash;
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
            TDIN_chatlib.IPUser ipUser = new TDIN_chatlib.IPUser(user.Username, user.Name, address);
            TDIN_chatlib.UserSession session = new TDIN_chatlib.UserSession(user.Username, user.Name, generateRandomHash());

            sessions.Add(session.SessionHash, ipUser);

            // force active client list to be rebuilt on next user query
            _tempIPList = null;
            
            
            // Mudei um pouco aqui as coisas, falta então fazeres a tua classe interna com toda a informação,
            // tipo base de dados, ou usares o LoginUser que até agora acho que tem tudo o que é preciso relativamente ao user (como se fosse para guardar na BD)
            //activeClients.Add(new_user);
            // Build a session and return it.

            Console.WriteLine("* [" + session.SessionHash + "] New user: " + session.Username);

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

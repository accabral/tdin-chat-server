using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public interface ChatSeverInterface
    {
        IList<IPAddress> getActiveClients();

        /// <summary>Chamado pelo cliente quando se pretende registar no server.
        /// É fornecido o username e password do cliente, caso não esteja registado o servidor deve registar um novo utilizador.
        /// </summary>
        /// <exception cref="ChatException">Em caso de não ser possível registar novo user ou password estiver errada</exception>
        /// <returns>Em caso de sucesso a hash de sessão, em caso de erro null</returns>
        string registerClient(IPAddress address, string user, string pass);


        /// <summary>Chamado pelo cliente quando se pretende desconectar do server</summary>
        /// <param name="hashCode">hash retornado pelo server em registerClient</param>
        void disconnectClient(string hashCode);

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    interface ChatSeverInterface
    {
        IList<IPAddress> getActiveClients();

        // Chamado pelo cliente quando se pretende registar no server
        // deve retornar uma hash aleatória única
        string register(IPAddress address);

        // Chamado pelo cliente quando se pretende desconectar do server
        void disconnect(string hashCode);
    }
}

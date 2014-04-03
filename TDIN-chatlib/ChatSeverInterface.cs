using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    public interface ChatSeverInterface
    {

        /// <summary>
        /// Retorna a lista actual dos clientes activos
        /// </summary>
        IList<IPUser> getActiveClients();

        /// <summary>Chamado pelo cliente quando se pretende registar no server.
        /// É fornecido o username e password do cliente no ChatUser, caso não esteja registado o servidor deve registar um novo utilizador.
        /// </summary>
        /// <param name="user">Em caso de registo os campos deverão estar todos preenchidos, em caso de login apenas é necessário o user e a password</param>
        /// <exception cref="ChatException">Em caso de não ser possível registar novo user ou password estiver errada</exception>
        /// <returns>Em caso de sucesso retorna um UserSession com todos os dados preenchidos, em caso de erro deve atirar uma excepção e retornar null</returns>
        UserSession registerClient(string uid, IPAddress address, LoginUser user);


        /// <summary>Utilizado para obter informação sobre um utilizador</summary>
        /// <exception cref="ChatException">Em caso de não ser possível encontrar o utilizador</exception>
        /// <returns>Em caso de sucesso retorna um User com todos todos os dados preenchidos</returns>
        User queryUser(string username);


        /// <summary>Chamado pelo cliente quando se pretende desconectar do server</summary>
        /// <param name="hashCode">hash retornado pelo server em registerClient</param>
        void disconnectClient(string hashCode);

    }
}

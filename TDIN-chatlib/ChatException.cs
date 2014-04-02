using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDIN_chatlib
{
    [Serializable()]
    public class ChatException: System.Exception
    {
        public ChatException(string message)
            : base(message)
        {
        }

    }
}

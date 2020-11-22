using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzh
{
      public class MessageEventArgs :EventArgs
     {
        public string Message;
        public MessageEventArgs(string msg)
        {
            Message = msg;
        }
      }
}

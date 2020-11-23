using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dzh
{
   public class Worker:BaseThread
   {
        
        public Worker()
        {
            
        }
        /// <summary>
        /// 重写父类方法
        /// </summary>
        public override void Run()
        {
            while (IsAlive == true)
            {
                  
            }
        }
   }
}

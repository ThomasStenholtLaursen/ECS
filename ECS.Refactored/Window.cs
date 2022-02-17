using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Refactored
{
    public class Window : IRegulate
    {
        public void TurnOff()
        {
            Console.WriteLine("Window closed");
        }

        public void TurnOn()
        {
            Console.WriteLine("Window opened");
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Refactored
{
    public interface IRegulate
    {
        void TurnOff();
        void TurnOn();
        bool RunSelfTest();
    }
}

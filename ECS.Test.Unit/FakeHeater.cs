using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;

namespace ECSTestUnit
{
    public class FakeHeater : IRegulate
    {
        public int TurnOnCount { get; set; } = 0;
        public int TurnOffCount { get; set; } = 0;
        public void TurnOff()
        {
            TurnOffCount++;
        }

        public void TurnOn()
        {
            TurnOnCount++;
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}

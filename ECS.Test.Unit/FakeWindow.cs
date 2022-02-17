using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;

namespace ECSTestUnit
{
    public class FakeWindow : IRegulate
    {

        public int TurnOnCount { get; set; }
        public int TurnOffCount { get; set; }
        public bool RunSelfTest()
        {
            return true;
        }

        public void TurnOff()
        {
            TurnOffCount++;
        }

        public void TurnOn()
        {
            TurnOnCount++;
        }
    }
}

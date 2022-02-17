using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ECS.Refactored;

namespace ECSTestUnit
{
    public class FakeSensor : ISensor
    {
        public int GetSample()
        {
            return 10;
        }

        public bool RunSelfTest()
        {
            throw new NotImplementedException();
        }
    }
}

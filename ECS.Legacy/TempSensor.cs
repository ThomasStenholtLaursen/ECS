using System;

namespace ECS.Legacy
{
    internal class TempSensor
    {
        private Random gen = new Random();
        
        public int GetSample()
        {
            return gen.Next(-5, 45);
        }

        public bool RunSelfTest()
        {
            return true;
        }
    }
}
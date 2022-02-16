using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Refactored
{
    public class ECS
    {
        private readonly ISensor _tempSensor;
        private readonly IRegulate _regulater;
        public int Threshold { get; private set; }

        public ECS(int thr, ISensor sensor, IRegulate regulator)
        {
            Threshold = thr;
            _tempSensor = sensor;
            _regulater = regulator;
        }

        public void Regulate()
        {
            var t = _tempSensor.GetSample();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < Threshold)
                _regulater.TurnOn();
            else
                _regulater.TurnOff();
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetSample();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _regulater.RunSelfTest();
        }
    }
}

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
        private readonly IRegulate _heater;
        public int Threshold { get; private set; }

        public ECS(int thr)
        {
            Threshold = thr;
            _tempSensor = new TempSensor();
            _heater = new Heater();
        }

        public void Regulate()
        {
            var t = _tempSensor.GetSample();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < Threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetSample();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}

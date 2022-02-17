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
        private readonly IRegulate _window;
        public int ThresholdLower { get; set; }
        public int ThresholdUpper { get; set; }


        public ECS(int thrLower, int thrUpper, ISensor sensor, IRegulate heater, IRegulate window)
        {
            ThresholdLower = thrLower;
            ThresholdUpper = thrUpper;
            _tempSensor = sensor;
            _heater = heater;
            _window = window; 
        }

        public void Regulate()
        {
            var t = _tempSensor.GetSample();
            Console.WriteLine($"Temperatur measured was {t}");
            
            if (t > ThresholdUpper)
                _window.TurnOn();
            else
            {
                _window.TurnOff();
                if (t < ThresholdLower)
                    _heater.TurnOn();
                else
                    _heater.TurnOff();
            }
                
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetSample();
        }

        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest() && _window.RunSelfTest();
        }
    }
}

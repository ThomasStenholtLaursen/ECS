using System;

namespace ECS.Legacy
{
    public class ECS
    {
        private readonly TempSensor _tempSensor;
        private readonly Heater _heater;
        private int _threshold;

        public ECS(int thr)
        {
            SetThreshold(thr);
            _tempSensor = new TempSensor();
            _heater = new Heater();
        }

        public void Regulate()
        {
            var t = _tempSensor.GetSample();
            Console.WriteLine($"Temperatur measured was {t}");
            if (t < _threshold)
                _heater.TurnOn();
            else
                _heater.TurnOff();
        }

        public int GetCurTemp()
        {
            return _tempSensor.GetSample();
        }

        public void SetThreshold(int thr)
        {
            _threshold = thr;
        }

        public int GetThreshold()
        {
            return _threshold;
        }
        public bool RunSelfTest()
        {
            return _tempSensor.RunSelfTest() && _heater.RunSelfTest();
        }
    }
}

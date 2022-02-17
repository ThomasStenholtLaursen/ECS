using ECS.Refactored;
using NUnit.Framework;
using ECS = ECS.Refactored.ECS;

namespace ECSTestUnit
{
    public class Tests
    {
        private FakeHeater _heater;
        private FakeSensor _sensor;
        private FakeWindow _window;
        private global::ECS.Refactored.ECS _uut;

        [SetUp]
        public void Setup()
        {
            _window = new FakeWindow();
            _heater = new FakeHeater();
            _sensor = new FakeSensor();
            _uut = new global::ECS.Refactored.ECS(10, 15, _sensor, _heater, _window);
        }

        [Test]
        public void UnitTestOfGetCurTemp()
        {
            int test = _uut.GetCurTemp();
            Assert.That(test,Is.EqualTo(10));
        }

        [Test]
        public void UnitTestOfRegulate()
        {
            _uut.Regulate();
            
            Assert.That(_heater.TurnOnCount, Is.EqualTo(0));
            Assert.That(_heater.TurnOffCount, Is.EqualTo(1));

            Assert.That(_window.TurnOnCount, Is.EqualTo(0));
            Assert.That(_window.TurnOffCount, Is.EqualTo(1));

        }

        //[TestCase(9, 1, 0)]
        //[TestCase(14, 0,1)]
        //[TestCase(6, 1,0)]
        //[TestCase(15, 0,1)]
        //int threshold, int turnon, int turnoff
        [Test]
        public void UnitTestOfRegulate_multiple()
        {
            _uut.Regulate(); //Lower threshold = 10, Upper = 15

            Assert.That(_heater.TurnOnCount, Is.EqualTo(0));
            Assert.That(_heater.TurnOffCount, Is.EqualTo(1));

            Assert.That(_window.TurnOnCount, Is.EqualTo(0));
            Assert.That(_window.TurnOffCount, Is.EqualTo(1));

            _uut.ThresholdLower = 9;
            _uut.ThresholdUpper = 11;
            _uut.Regulate();

            Assert.That(_heater.TurnOnCount, Is.EqualTo(1));
            Assert.That(_heater.TurnOffCount, Is.EqualTo(1));

            Assert.That(_window.TurnOnCount, Is.EqualTo(0));
            Assert.That(_window.TurnOffCount, Is.EqualTo(2));

            _uut.ThresholdLower = 8;
            _uut.ThresholdUpper = 9;
            _uut.Regulate();

            Assert.That(_heater.TurnOnCount, Is.EqualTo(2));
            Assert.That(_heater.TurnOffCount, Is.EqualTo(1));

            Assert.That(_window.TurnOnCount, Is.EqualTo(1));
            Assert.That(_window.TurnOffCount, Is.EqualTo(3));

            _uut.ThresholdLower = 11;
            _uut.ThresholdUpper = 15;
            _uut.Regulate();

            Assert.That(_heater.TurnOnCount, Is.EqualTo(3));
            Assert.That(_heater.TurnOffCount, Is.EqualTo(2));

            Assert.That(_window.TurnOnCount, Is.EqualTo(1));
            Assert.That(_window.TurnOffCount, Is.EqualTo(4));

            //_uut.ThresholdLower = 26;
            //_uut.Regulate();
            //
            //Assert.That(_heater.TurnOnCount, Is.EqualTo(2));
        }   //


    }
}
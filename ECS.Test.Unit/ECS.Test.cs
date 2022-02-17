using ECS.Refactored;
using NUnit.Framework;
using ECS = ECS.Refactored.ECS;

namespace ECSTestUnit
{
    public class Tests
    {
        private FakeHeater _regulator;
        private FakeSensor _sensor;
        private global::ECS.Refactored.ECS _uut;

        [SetUp]
        public void Setup()
        {

            _regulator = new FakeHeater();
            _sensor = new FakeSensor();
            //_uut = new global::ECS.Refactored.ECS(20, _sensor, _regulator);
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
            
            Assert.That(_regulator.TurnOnCount, Is.EqualTo(1));

        }

        //[TestCase(9, 1, 0)]
        //[TestCase(14, 0,1)]
        //[TestCase(6, 1,0)]
        //[TestCase(15, 0,1)]
        //int threshold, int turnon, int turnoff
        [Test]
        public void UnitTestOfRegulate_multiple()
        {
            _uut.Regulate();
            
            Assert.That(_regulator.TurnOnCount, Is.EqualTo(1));
            _uut.ThresholdLower = 10;
            _uut.Regulate();
            Assert.That(_regulator.TurnOffCount, Is.EqualTo(1));
            _uut.ThresholdLower = 20;
            _uut.Regulate();
            Assert.That(_regulator.TurnOnCount, Is.EqualTo(2));
        }


    }
}
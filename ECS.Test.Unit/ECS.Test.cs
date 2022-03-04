using NSubstitute;
using ECS.Refactored;
using NUnit.Framework;

namespace ECS.Test.Unit
{
    public class Tests
    {
        private IRegulate _fakeHeater;
        private ISensor _fakeSensor;
        private IRegulate _fakeWindow;
        private ECS.Refactored.ECS _uut;
            
        [SetUp]
        public void Setup()
        {
            _fakeHeater = Substitute.For<IRegulate>();
            _fakeSensor = Substitute.For<ISensor>();
            _fakeWindow = Substitute.For<IRegulate>();
            _uut = new ECS.Refactored.ECS(18, 25, _fakeSensor, _fakeHeater, _fakeWindow);

        }

        [Test]
        public void Regulate_LowTemp_HeaterOn()
        {
            _fakeSensor.GetSample().Returns(17);

            _uut.Regulate();

            _fakeHeater.Received(1).TurnOn();
        }
        [Test]
        public void Regulate_TempOnLowThres_HeaterNotCalled()
        {
            _fakeSensor.GetSample().Returns(18);

            _uut.Regulate();

            _fakeHeater.DidNotReceive();
        }
        [Test]
        public void Regulate_TempHigh_WindowOpened()
        {
            _fakeSensor.GetSample().Returns(26);

            _uut.Regulate();

            _fakeWindow.Received(1).TurnOn();
        }


    }
}
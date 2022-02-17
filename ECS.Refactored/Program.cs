using System;

namespace ECS.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.Refactored");
            ISensor sensor = new TempSensor();
            IRegulate heater = new Heater();
            IRegulate window = new Window();

            
            var control = new ECS(20, 30, sensor, heater, window);

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();
            }
        }
    }
}

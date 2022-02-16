using System;

namespace ECS.Refactored
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing ECS.Refactored");
            var sensor = new TempSensor();
            var regulator = new Heater();
            // Make an ECS with a threshold of 23
            var control = new ECS(23, sensor, regulator);

            for (int i = 1; i <= 15; i++)
            {
                Console.WriteLine($"Running regulation number {i}");

                control.Regulate();
            }
        }
    }
}

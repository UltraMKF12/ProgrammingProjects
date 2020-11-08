using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello_feladatok_2
{
    interface IVehicle
    {
        void Start();
        void Stop();
    }
    
    class Car : IVehicle
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Status { get; set; }
    
        public void Start()
        {
            Console.WriteLine("Starting the car.");
        }
    
        public void Stop()
        {
            Console.WriteLine("Stopping the car.");
        }
    }
    
    class Plane : IVehicle
    {
        public string Color { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Capacity { get; set; }
    
        public void Start()
        {
            Console.WriteLine("WE ARE GOING TO FLY YEAH");
        }
    
        public void Stop()
        {
            Console.WriteLine("DOWN DOWN DOWN TO EARTH");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IVehicle[] vehicles = new IVehicle[5];
            vehicles[0] = new Car();
            vehicles[1] = new Car();
            vehicles[2] = new Car();
            vehicles[3] = new Plane();
            vehicles[4] = new Plane();

            while(true)
            {
                Console.WriteLine("Type in the vehicle index 0-4 >>> ");
                int index = Convert.ToInt32(Console.ReadLine());
                if (index == -1) break;

                Console.WriteLine("start or stop >>> ");
                switch(Console.ReadLine())
                {
                    case "start":
                        vehicles[index].Start();
                        break;
                    
                    case "stop":
                        vehicles[index].Stop();
                        break;
                }
            }
        }
    }
}

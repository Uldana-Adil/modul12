using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M_12hw
{
    public abstract class Car
    {
        public string CarType { get; protected set; }
        public int Speed { get; protected set; }
        public int Position { get; protected set; }

        public event EventHandler<string> FinishEvent;

        public Car(string carType)
        {
            CarType = carType;
            Position = 0;
        }

        public void StartRace()
        {
            Console.WriteLine($"{CarType} is starting the race!");
            Random random = new Random();
            Speed = random.Next(5, 20);
        }

        public void Move()
        {
            Position += Speed;
            if (Position >= 100)
            {
                OnFinish();
            }
        }

        protected virtual void OnFinish()
        {
            FinishEvent?.Invoke(this, $"{CarType} finished the race!");
        }
    }

    public class SportsCar : Car
    {
        public SportsCar() : base("Sports Car") { }
    }

    public class PassengerCar : Car
    {
        public PassengerCar() : base("Passenger Car") { }
    }

    public class Truck : Car
    {
        public Truck() : base("Truck") { }
    }

    public class Bus : Car
    {
        public Bus() : base("Bus") { }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace M_12hw
{
    public class RaceGame
    {
        public delegate void StartRaceDelegate();
        public event StartRaceDelegate StartRaceEvent;

        public RaceGame()
        {
            StartRaceEvent += StartRace;
        }

        public void StartRace()
        {
            SportsCar sportsCar = new SportsCar();
            PassengerCar passengerCar = new PassengerCar();
            Truck truck = new Truck();
            Bus bus = new Bus();

            sportsCar.FinishEvent += FinishHandler;
            passengerCar.FinishEvent += FinishHandler;
            truck.FinishEvent += FinishHandler;
            bus.FinishEvent += FinishHandler;

            Console.WriteLine("Race Started!");

            sportsCar.StartRace();
            passengerCar.StartRace();
            truck.StartRace();
            bus.StartRace();

            while (true)
            {
                sportsCar.Move();
                passengerCar.Move();
                truck.Move();
                bus.Move();

                Console.WriteLine($"Sports Car: {sportsCar.Position} | Passenger Car: {passengerCar.Position} | Truck: {truck.Position} | Bus: {bus.Position}");

                Thread.Sleep(100);

                if (sportsCar.Position >= 100 || passengerCar.Position >= 100 || truck.Position >= 100 || bus.Position >= 100)
                {
                    break;
                }
            }
        }

        private void FinishHandler(object sender, string message)
        {
            Console.WriteLine(message);
            Console.WriteLine("Race Finished!");
        }
    }

    class Program
    {
        static void Main()
        {
            RaceGame raceGame = new RaceGame();
            raceGame.StartRaceEvent.Invoke();

            Console.ReadLine();
        }
    }


}

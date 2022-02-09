using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.data
{
    public class Train
    {
        // Auto-implemented Properties
        public Engine Engine { get; private set; }

        public int MaxGrossWeight
        {
            get
            {
                return Utilities.RoundtoNearestHundred(Engine.HP * 2000);
            }
        }
        public List<RailCar> RailCars { get; private set; } // Add new Car List
        public int GrossWeight // Create new method CalculateGrossWeight
        {
            get
            {
                int engineWeight = Engine.Weight;
                int carWeight = 0;
                {
                    foreach (RailCar car in RailCars)
                    {
                        carWeight = carWeight + car.GrossWeight;
                    }
                }
                return Utilities.RoundtoNearestHundred(engineWeight + carWeight);
            }
        }
        public int TotalCars
        {
            get
            {
                if (RailCars == null) // no need if we declare new list at beginning
                    return 0;
                return RailCars.Count();
            }
        }

        // Constructor
        public Train(Engine givenEngine)
        {
            if (givenEngine == null)
                throw new ArgumentNullException("A train must have at least a single engine.");
            Engine = givenEngine;
            RailCars = new List<RailCar>();
        }

        // Behaviours (Methods)
        public void AddRailCar (RailCar car)
        {
            if ((GrossWeight + car.GrossWeight) > MaxGrossWeight)
                throw new ArgumentException("Cannot add new car: " +
                    "gross weight exceeded the maximum gross weight allowed for the train.");
            if (RailCars == null) // no need if we declare new list at first
            {
                RailCars = new List<RailCar>();
            }
            if (car != null)
            {
                RailCars.Add(car);
            }
        }
        // ADD NEW METHOD HERE!
/*        private int CalculateGrossWeightOfCars()
        {
            int totalWeightOfCars = 0;
            foreach (RailCar car in RailCars)
            {
                totalWeightOfCars += car.GrossWeight;
            }
            return totalWeightOfCars;
        }
*/    }
}

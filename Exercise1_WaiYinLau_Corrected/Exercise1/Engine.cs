using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.data
{
    public class Engine
    {
        // Fields
        private int _HP;
        private string _Model;
        private string _SerialNumber;
        private int _Weight;

        // Properties
        public int HP
        { 
            get 
            { 
                return _HP; 
            }
            private set
            {
                if (!Utilities.IsPositive(value))
                {
                    throw new ArgumentException("Create Engine Failed: " +
                        "Horse Power must be a positive number.");
                }
                else if (value < 3500 || value > 5500)
                    throw new ArgumentOutOfRangeException("Create Engine Failed: " +
                        "Horse Power must be a positive whole number between 3,500 and 5,500.");
                _HP = Utilities.RoundtoNearestHundred(value);
            }        
        }
        public string Model
        {
            get
            {
                return _Model;
            }
            private set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Create Engine Failed: " +
                        "Model cannot leave blank or null.");
                _Model = value.Trim();
            }
        }
        public string SerialNumber
        {
            get
            {
                return _SerialNumber;
            }
            private set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Create Engine Failed: " +
                        "Serial Number cannot leave blank or null.");
                _SerialNumber = value.Trim();
            }
        }
        public int Weight
        {
            get 
            { 
                return _Weight; 
            }
            private set 
            {
                if (!Utilities.IsPositiveNonZero(value))
                    throw new ArgumentException("Create Engine Failed: " +
                        "Weights must be positive and non-zero whole numbers");               
                _Weight = Utilities.RoundtoNearestHundred(value);
            }
        }

        // Constructor
        public Engine (string model, string serialnumber, int weight, int hp)
        {
            Model = model;
            SerialNumber = serialnumber;
            Weight = weight;
            HP = hp;
        }

        // Behaviour
        public override string ToString()
        {
            return $"{Model},{SerialNumber},{Weight},{HP}";
        }
    }
}

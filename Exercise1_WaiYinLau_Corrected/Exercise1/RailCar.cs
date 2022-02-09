using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem.data
{
    public class RailCar
    {
        // Fields
        private int _Capacity;
        private int _Lightweight;
        private int _LoadLimit;
        private string _SerialNumber;
        private RailCarType _Type; // No need to set field for RailCarType

        // Fully-implemented Properties
        public int Capacity 
        { 
            get 
            {
                return _Capacity;
            }
            private set 
            {
                if (!Utilities.IsPositiveNonZero(value))
                    throw new ArgumentException("Create RailCar Failed: " +
                        "Capacity must be positive and non-zero whole numbers");
                _Capacity = Utilities.RoundtoNearestHundred(value); // Not rounding -> Throw Error Message

                // Add Capacity > LoadLimit Error Here
            }
        }
        public int Lightweight
        {
            get
            {
                return _Lightweight;
            }
            private set
            {
                if (!Utilities.IsPositiveNonZero(value))
                    throw new ArgumentException("Create RailCar Failed: " +
                        "Light Weights must be positive and non-zero whole numbers");
                _Lightweight = Utilities.RoundtoNearestHundred(value); // Not rounding -> Throw Error Message
            }
        }
        public int LoadLimit
        {
            get
            {
                return _LoadLimit;
            }
            private set
            {
                if (!Utilities.IsPositiveNonZero(value))
                    throw new ArgumentException("Create RailCar Failed: " +
                        "Load Limit must be positive and non-zero whole numbers");
                _LoadLimit = Utilities.RoundtoNearestHundred(value);
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
                    throw new ArgumentNullException("Create RailCar Failed: " +
                        "Serial Number cannot leave blank or null.");
                _SerialNumber = value.Trim();
            }
        }
        public RailCarType Type  // Auto implemented instead of Full implemented
        {
            get 
            { 
                return _Type;
            }
            private set
            {
                _Type = value;
            }
        }

        // Auto-implemented Properties
        public int GrossWeight { get; private set; }
        public bool Inservice { get; private set; } // Public Set instead of Private
        public bool IsFull
        {
            get 
            {
                if ((GrossWeight - Lightweight) > Capacity * 0.9) // Netweight > (Capacity * 0.9)
                {
                    return true;
                }
                return false;          
            }
        }
        public int NetWeight 
        {
            get 
            {
                return (GrossWeight - Lightweight);
            }
        }

        // Constructor
        public RailCar (string serialnumber, int lightweight, int capacity, int loadlimit, 
                        RailCarType type, bool inservice)
        {
            SerialNumber = serialnumber;
            Lightweight = lightweight;
            if (capacity > loadlimit)
                throw new ArgumentException("Create RailCar Failed: " +
                    "Capacity must always less than the Load Limit."); // Put in Capacity Set instead
            Capacity = capacity;
            LoadLimit = loadlimit;
            Type = type;
            Inservice = inservice;
            // Add GrossWeight = lighteweight to initiate GrossWeight
        }

        // Behaviours
        public void RecordScaleWeight(int grossweight)
        {
            if (!Utilities.IsPositiveNonZero(grossweight))
                throw new ArgumentException("Record Scale Failed : " +
                    "Weights must be positive and non-zero whole numbers"); // Display weight input
            else if (grossweight < Lightweight) // Display weight input
                throw new ArgumentOutOfRangeException("Record Scale Failed : Scale Error - " +
                    "Gross Weights must be greater than the Light Weight of the Rail Car");
            else if (grossweight > (LoadLimit + Lightweight)) // Display weight input
                throw new ArgumentOutOfRangeException("Record Scale Failed : Unsafe Load - " +
                    "For safety, a rail car should be loaded so that Gross Weight " +
                    "is less than the sum of its stenciled Load Limit + Light Weight.");
            GrossWeight = Utilities.RoundtoNearestHundred(grossweight);
        }

        public override string ToString()
        {
            return $"{SerialNumber},{Lightweight},{Capacity},{LoadLimit},{Type},{Inservice}";
        }
    }
}

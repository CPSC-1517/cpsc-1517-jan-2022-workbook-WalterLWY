using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainSystem
{
    public class Utilities
    {
        public static bool IsEmpty(string value)
        {
            bool valid = false;
            if (string.IsNullOrWhiteSpace(value))
            {
                valid = true;
            }
            return valid;
        }
        public static int RoundtoNearestHundred(double value)
        {
            int result = (int)Math.Round(value / 100);
            if (value > 0 && result == 0)
            {
                result = 1;
            }
            return (int)result * 100;
        }

        //  Overloaded Methods - IsPositve
        public static bool IsPositive(int value)
        {
            bool valid = false;
            if (value >= 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositive(double value)
        {
            bool valid = false;
            if (value >= 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositive(decimal value)
        {
            bool valid = false;
            if (value >= 0.0m)
            {
                valid = true;
            }
            return valid;
        }

        //  Overloaded Methods - IsPositveNonZero
        public static bool IsPositiveNonZero(int value)
        {
            bool valid = false;
            if (value > 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositiveNonZero(double value)
        {
            bool valid = false;
            if (value > 0)
            {
                valid = true;
            }
            return valid;
        }
        public static bool IsPositiveNonZero(decimal value)
        {
            bool valid = false;
            if (value > 0.0m)
            {
                valid = true;
            }
            return valid;
        }

    }
}

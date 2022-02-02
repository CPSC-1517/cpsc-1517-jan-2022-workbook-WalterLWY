using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Data
{
    public class Person
    {
        // Example of a Composite Class
        //  A composite class uses other classes in its definition
        //  A composite class is recognised with the phrase "has a" class
        //  This class of Person "has a" resident address

        // An Inherited class extends another class in its definition
        //  An inherited class is recognised with the phrase "is a" class
        //  assume a general class called Transportation
        //  then we can "extend" this class to more specific classes
        //      public class Vehicle : Transportation
        //      public class Bike : Transportation
        //      public class Boat : Transportation

        //  Each instance of this will represent an individual
        //  This class will define the following characteristics of a person
        //      FirstName, LastName, the current residential address, list of employment position

        private string _FirstName;
        private string _LastName;

        public string FirstName
        {
            get { return _FirstName; }
            set 
            { 
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("First name is required.");                 
                _FirstName = value; 
            }
        }
        public string LastName
        {
            get { return _LastName; }
            set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Last name is required.");
                _LastName = value;
            }
        }

        // Composition actually uses the other class as a property / field within
        //  the definition of the class being defined 
        public ResidentAddress Address;

        // Composition

        public List<Employment> EmploymentPosition { get; set; }

/*        public Person() // Default Constructor 
        {
            // If an instance of List<T> is not created and assigned then 
            //  the property will have an initial value of null           
            EmploymentPosition = new List<Employment> ();

            // Option 1: assign some default value to the strings
            //  Since FirstName and LastName need to have values
            //  you can assign default literals to the properties
            FirstName = "unknown";
            LastName = "unknown";
        }
*/
        // Option 2: 
        //  DO NOT code a "Default" constructor
        //  Code ONLY the "Greedy" constructor
        //      If only a greedy constructor exists for the class, the ONLY
        //      way to possibly create an instance for the class within
        //      the program is to use the constructor when the class instance 
        //      is created

        public Person (string firstname, string lastname,
                        List<Employment> employmentpositions, 
                        ResidentAddress address)
        {
            FirstName = firstname;
            LastName = lastname;
            if (employmentpositions != null)
                EmploymentPosition = employmentpositions;
            else 
                // allows a null value and the class to have an 
                //  emply List<T>
                EmploymentPosition = new List<Employment>();
            Address = address;
        }

    }
}

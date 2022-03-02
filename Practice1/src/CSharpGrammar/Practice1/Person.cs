#region Default (given) Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

#region Additional Namespaces
using System.Text.Json.Serialization;
#endregion

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
            private set 
            { 
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("First name is required.");                 
                _FirstName = value; 
            }
        }
        public string LastName
        {
            get { return _LastName; }
            private set
            {
                if (Utilities.IsEmpty(value))
                    throw new ArgumentNullException("Last name is required.");
                _LastName = value;
            }
        }

        // Composition actually uses the other class as a property / field within
        //  the definition of the class being defined 
        // In this example Address is a field (data member)

        // This is a field NOT a property
        // Yes: the datatype is a developer defined datatype (struct)
        // JSON Serialization has no problem in creating the named pair 
        //  for this field due to the IncludeFields option
        // HOWEVER, the deserializer does have a problem
        // Solution: use an annotation to indicate that the field 
        //  is included for use by JSON
        // To use this annotation, you will need to add a namespace (see above)
        //  in resolving the conflict
        [JsonInclude]
        public ResidentAddress Address;

        // Composition

        public List<Employment> EmploymentPositions { get; private set; }

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

        // NOTE: FOR READING JSON FILES!!!!!
        // Your constructor parameter names MUST MATCH your property variable names.
        // the order in which your properties physically code in the class, does NOT
        // affect the reading
        // The parameter names are NOT case sensitive
        // The order of the parameters on the constructor does not affect reading
        public Person (string firstname, string lastname, ResidentAddress address,
                        List<Employment> employmentpositions)
        {
            FirstName = firstname;
            LastName = lastname;
            if (employmentpositions != null)
                EmploymentPositions = employmentpositions;
            else 
                // allows a null value and the class to have an 
                //  emply List<T>
                EmploymentPositions = new List<Employment>();
            //IF your parameter name is identical to the property name, to have your
            //  code work appropriately, place the key word "this." in front of the 
            //  property  reference
            this.Address = address;
        }

        public void ChangeName (string firstname, string lastname)
        {
            FirstName = firstname.Trim();
            LastName = lastname.Trim();
        }

        public void AddEmployment (Employment employment)
        {
            EmploymentPositions.Add(employment);
        }
    }
}

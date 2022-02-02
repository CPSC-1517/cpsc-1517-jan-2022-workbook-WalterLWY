using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1.Data
{
    public class Employment
    {
        // An instance of this class will hold data about a person's employment
        // The code of this class is the definition of that data
        // The characteristics (data) of the class
        //   Title, SupervisoryLevel, Year of Employment within the company

        // The 4 components of a class definition are:
        //   Data fields
        //   Property
        //   Constructor
        //   Behavior (Method)

        //   Data fields
        //      are storage area in your class
        //      these are treated as variables
        //      these may be public, private/ public readonly
        private string _Title;
        private double _Years;

        //   Property
        //      These are access techniques to retrieve or set data in
        //      your class without directly touching the storage data field

        //   Fully-implemented Property
        //      a) a declared storage area (data field)
        //      b) a declared proparty signature
        //      c) a coded get "method"
        //      d) an optional codedd set "method"

        //      Use when: 
        //      a) if you are storing the associate data in an explicitly declared data field
        //      b) if you are during validation access incoming data
        //      c) creating a property that generates output from other data sources
        //         within the class (readonly properties); this property would have only
        //         a get method
        public string Title
        {
            get 
            {
                // Accessor
                //  The get "method" will return the contents of a data field(s)
                //  of an expression
                return _Title;
            }
            set
            {
                // Mutator
                //  The set "method" receives an incoming value and places it in the
                //  associated data field. 
                //  During the setting, you might wish to validate the incoming data
                //  During the setting, you might wish to do some type of logical 
                //      processing using the data to set another field
                //  The incoming piece of data is referred to using the keyword "value"

                //  Ensure that the incoming data is not null or empty or just whitespace
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("Title is a required piece of data.");
                }             
                
                // Data is considered valid (.net 6 new feature)
                _Title = value;
            }

        }

        //   Auto-implemented Property
        //      These properties differ only in syntax
        //      Each property is responsible for a single piece of data
        //      These properties do NOT reference a declared private data member
        //      The system generates an internal storage area of the return data type
        //      The system manages the internal storage for the accessor and mutator
        //      This is NO additional logic applied to the data value


        //  Using an enum for this field will AUTOMATICALLY restrict the values 
        //      this property can contain
        public SupervisoryLevel Level { get; set; }

        //  This property Years could be coded as either a fully implemented property
        //      or as an auto-implemented property

        public double Years
        {
            get { return _Years; }
            set 
            { 
                if (!Utilities.IsPositive(value));
                {
                    throw new ArgumentNullException("Year cannot be a negative value.");
                }
                _Years = value;
            }
        }

        //   Constructor
        //      is to initialize the physical object (instance) during its creation
        //      the result of creation is ensure the coder gets an instance in 
        //      a known state
        
        //      if your class defintion has NO constructor coded, then the data members /
        //      auto implemented properties are set to the C# default data type value

        //      You can code one or more constructors in your class definition 
        //      If YOU CODE A CONSTRUCTOR FOR THE CLASS, YOU ARE RESPONSIBLE FOR ALL
        //      CONSTRUCTORS USED BY THE CLASS!!

        //      Generally, if you are going to code your own constructor(s) you code two types
        //      a) Default: this constructor does NOT take in any parameters (it mimics the default 
        //                  system constructor)      
        //      b) Greedy:  this constructor has list of parameters, on for each property, declare
        //                  for incoming data

        //      syntax: accesstype classname ([list of parameters]) {constructor code body}

        //      IMPORTANT:  The constructor DOES NOT have a return datatype
        //                  You DO NOT call a constructor directly, called using the new operator

        //  Default Constructor
        public Employment()
        {
            // Constructor Body
            // a) empty 
            // b) you COULD assign literal values to your properties with this constructor
            Level = SupervisoryLevel.TeamMember;
            Title = "unknown";
        }

        //  Greedy Constructor (you can have many different greedy constructors)
        public Employment(string title, SupervisoryLevel level, double years)
        {
            // Constructor Body
            // a) a parameter for each property
            // b) you COULD do validation within the constructor instead of the property
            // c) validation for public readonly data members
            //    validation for a property within a private set
            
            Title = title;
            Level = level;
            Years = years;
        }

        //   Behaviours (aka Method)
        //      Behaviours are no different than methods elsewhere

        //      Syntax: accesstype [static] returndatatype BehaviourName ([list of parameters]) 
        //              {Code Body}

        //      There maybe times you wish to obtain all the data in your instance
        //          all at once for display
        //      Generally to accomplish this, your class overrides the .ToString() method of classes

        public override string ToString()
        {
            // comma separated value list (csv)
            return $"{Title},{Level},{Years}";
        }

        public void SetEmployeeResponsibiltyLevel(SupervisoryLevel level)
        {
            // You could do validation within this method to ensure acceptable value
            if (level < 0)
                throw new Exception("Responsibilty Level must be positive");
            Level = level;
        }
    }
}

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
        
        public int Level { get; set; }

        //  This property Years could be coded as either a fully implemented property
        //      or as an auto-implemented property

        public double Years
        {
            get { return _Years; }
            set { _Years = value; }
        }


        //   Constructor

        //   Behavior (Method)




    }


}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice1
{
    //  Struct is another developer defined data type
    //      looks like a class definition
    //      struct however is a value type storage where as class is a reference type storage
    //      struct can have fields, properties, constructors and behaviours
    public struct ResidentAddress
    {
        public int Number;
        public string Address1;
        public string Address2;
        private string _Unit;
        private string _City;
        public string ProvinceState;

        public string Unit
        {
            get { return _Unit; }
            set { _Unit = value; }
        }

        public string City
        {
            get { return _City; }
            set { _City = value; }
        }

        public ResidentAddress(int Number, string Address1, string Address2,
                                string Unit, string City, string ProvinceState)
        {
            // Concern: parameter name is exactly the same as the struct/class field/property
            // Solution: use the keyword this. on your instance item
            // The keyword this references to the instance that you are currently 
            //      accessing in your program

            this.Number = Number;
            this.Address1 = Address1;
            this.Address2 = Address2;
            _Unit = Unit;
            _City = City;
            this.ProvinceState = ProvinceState; 

            // this.Address1 = this.Number.ToString(); 
            // to show that .this can be used on both left or right hand side
        }

        //  Note that no "default" constructor was created because I wish the program
        //      to assign the address with all necessary data at creation time
    }
}

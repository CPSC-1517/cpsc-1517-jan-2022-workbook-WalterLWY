using Practice1.Data;   // gives reference to the location of classes within 
                        //  the specified namespace
                        // this allows the developer to avoid having to 
                        //  use a fully qualified name every time a 
                        //  reference is made to a class in the namespace
using System; 
/* in .net 6 some using statement visible in .net 5 are 
   already implemented in the project and do not need 
   to be explicitly coded*/

/* there are still times that you will still need to code 
   using statements to explicitly reference other namespace*/

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World");

// Fully Qualified Name
//  Practice1.Data.Employment job = CreateJob ()
Employment Job = CreateJob();
ResidentAddress Address = CreateAddress();


static void DisplayString(string text)
{
    Console.WriteLine(text);
}

// TESTING 1 : CHECKING THE DEFAULT CONSTRUCTOR 
/*Employment CreateJob()
{
    Employment defaultJob = new Employment();
    DisplayString($"Good job {defaultJob.ToString()}");
    return defaultJob;
}
*/

// TESTING 2 : CHECKING THE GREEDY CONSTRUCTOR 
Employment CreateJob()
{
    Employment Job = null;  // a reference to a variable capable of holding an
                            // instance of Employment
                            // its initial value will be null
    try
    {
        Job = new Employment();
        DisplayString($"Default good job {Job.ToString()}");
        // Checking exceptions
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, 5.5);
        DisplayString($"Greedy good job {Job.ToString()}");

/*        // Bad data: Title ; Change SupervisoryLevel to number (cannot proceed)
        Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
*/        

/*        // Bad data: Negative Year ; Null (cannot proceed)
        Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5);
*/    }
    catch (ArgumentException ex) // Specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // General catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return Job;
}

ResidentAddress CreateAddress()
{
    ResidentAddress Address = new ResidentAddress();
    DisplayString($"Default Address {Address.ToString()}");
    Address = new ResidentAddress(10767, "106 ST NW", null, null, "Edmonton", "AB");
    DisplayString($"Greedy Address {Address.ToString()}");
    return Address;
}
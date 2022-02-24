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

// Create a Person 
Person Me = CreatePerson(Job, Address);
if (Me != null)
    DisplayPerson(Me);

ArrayReview(Me);

// Modulus Division
//  Operator is %
//  Example oddeven
//      If the number is divisable by 2, it is even, that is 0 as a reminder
//      If the number is not divisable by 2, it is odd, that is the reminder 
//      WILL NOT be zero
//      variable & 2 I can test  the result:
//      if(variable % 2 == 0) even else odd

//  Weight must be in multiples of 100
//      So a number is said to be a multiple of 100 if reminder is 0
//      if(variable % 100 == 0) is multiple else is NOT multiple

//  30000 % 100 result is 0 (300 * 100) 
//  38880 % 100 result is 80 (388.8 * 100)


static void DisplayString(string text)
{
    Console.WriteLine(text);
}

static void DisplayPerson(Person person)
{
    DisplayString($"{person.FirstName} {person.LastName}");
    DisplayString($"{person.Address.ToString()}");

    // in our example, the Person constructor ensures that EmploymentPosition
    //  exists (List was declared); this makes the need for the null mute
    if (person.EmploymentPosition != null)
    {
        // This loop is a forward moving pre-test loop
        // What it checks is "is there another link element to look out".
        // Yes: use the element
        // No: exit loop

        foreach (var emp in person.EmploymentPosition)
        {
            DisplayString($"{emp.ToString()}");
        }

        // A List<T> can actually be manipulated like a array
        // is a pre-test loop BUT does not check for an missing List<T>
        for (int i = 0; i < person.EmploymentPosition.Count; i++)
        {
            DisplayString(person.EmploymentPosition[i].ToString());
        }

        if (person.EmploymentPosition.Count > 0)
        {
            int x = 0;
            // is a post-test loop 
            do
            {
                DisplayString(person.EmploymentPosition[x].ToString());
                x++;
            } while (x < person.EmploymentPosition.Count);
        }
    }

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

        // Without string interpolation [NOT A GOOD CHOICE]
        // DisplayString("Greedy good job " + Job.ToString());


        /*        // Bad data: Title ; Change SupervisoryLevel to number (cannot proceed)
                Job = new Employment("", SupervisoryLevel.Supervisor, 5.5);
        */

        /*        // Bad data: Negative Year ; Null (cannot proceed)
                Job = new Employment("Boss", SupervisoryLevel.Supervisor, -5);
        */
    }
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

Person CreatePerson(Employment job, ResidentAddress address)
{
    List <Employment> Jobs = new List<Employment>(); // .net 6 = new () 
    Person thePerson = null;
    try
    {
/*        // Create a good person using greedy constructor NO Job List
        thePerson = new Person("DonNoJob", "Welch", null, address);
*/
        // Create a good person using greedy constructor with an empty Job List
        thePerson = new Person("DonEmptyJob", "Welch", Jobs, address);

        // Create a good person using greedy constructor with a Job List
        Jobs.Add(new Employment("worker", SupervisoryLevel.TeamMember, 2.1));
        Jobs.Add(new Employment("leader", SupervisoryLevel.TeamLeader, 7.8));
        Jobs.Add(job);
        thePerson = new Person("DonWithJob", "Welch", Jobs, address);

        // Exception testing
        //  no first name
        // thePerson = new Person(null, "Welch", Jobs, address);
        //  no last name
        // thePerson = new Person("DonWithJob", null, Jobs, address);

        // Can I change the firstname using an assignment statement
        // the Firstname is a private set.
        // you are NOT allowed to use a private set on the receiving side
        //  of an assignment statement.
        // THIS IS NOT COMPILE
        // thePerson.FirstName = "NewName";

        // Can I use a behaviour (method) to change the contents of a private
        //  set property?
        thePerson.ChangeName("Lowand", "Behold");

        // Can I add another job after the person instance was created
        thePerson.AddEmployment(new("DP IT", SupervisoryLevel.DepartmentHead, 0.8));
        // thePerson.AddEmployment(new Employment("DP IT", SupervisoryLevel.DepartmentHead, 0.8));

        // Can I change the public field Address directly
        ResidentAddress oldAddress = thePerson.Address;
        oldAddress.City = "Vancouver";
        thePerson.Address = oldAddress;
    }
    catch (ArgumentException ex) // Specific exception message
    {
        DisplayString(ex.Message);
    }
    catch (Exception ex) // General catch all
    {
        DisplayString("Run time error: " + ex.Message);
    }
    return thePerson;
}

void ArrayReview(Person person)
{
    // Declare a single-dimensional array size 5
    // In this declaration, the value in each element is set 
    //  to the datatype's default (numeric -> 0)
    int[] array1 = new int[5]; // one can use a literal for the size 
    // PrintArray(array1, 5, "Declare int array size 5");

    // Declare and set array elements 
    int [] array2 = new int[] { 1, 2, 4, 8, 16 };
    // PrintArray(array2, 5, "Declare int array size using a list of supplied values");

    // Alternate syntax
    // Size of the array is determined using the method .Count() of the collection
    //  using the inherited class IEnumerable (Array class derived from the base class IEnumerable 
    //  which is derived from its base class Collections)
    int[] array3 = new int[] { 1, 3, 6, 12, 24 };
    PrintArray(array3, array3.Count(), "Declare int array with just a list of supplied values");

    // OR using Length
    // Size of the array can be determined using the read-only property (just has a get{} of the 
    //  Array class called .Length
    PrintArray(array3, array3.Length, "Declare int array with just a list of supplied values");

    // Traversing to an array altering elements
    // Remember that the array when declared is physically created in memory
    // each element (cell) has a given value, even if it is the datatype default
    // when you are "adding" to an array you are really just altering the element value

}

void PrintArray(int[] array, int size, string text)
{
    Console.WriteLine($"\n{text}");
    // item represents an element in the array
    // array is your collection (array[])
    // processing will be start (0) to end (size-1)
    foreach (var item in array)
    {
        Console.Write($"{item}, ");
    }
    Console.WriteLine("\n");

    // Using the for loop this display output the 
    //      array back to the front
    for(int i = size - 1; i >= 0; i--)
    {
        Console.Write($"{array[i]}, ");
    }


}
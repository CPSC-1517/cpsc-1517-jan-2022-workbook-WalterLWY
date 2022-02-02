using System; 
/* in .net 6 some using statement visible in .net 5 are 
   already implemented in the project and do not need 
   to be explicitly coded*/

/* there are still times that you will still need to code 
   using statements to explicitly reference other namespace*/

// See https://aka.ms/new-console-template for more information
DisplayString("Hello World");

static void DisplayString(string text)
{
    Console.WriteLine(text);
}


using System;
using System.Collections.Generic;
using System.Text;

namespace Addressbookuc6
{
    class Addressbook
    {
        string command = "";

        public static void PrintPerson(Person2 person2)
        {
            Console.WriteLine("First Name: " + person2.FirstName);
            Console.WriteLine("Last Name: " + person2.LastName);
            Console.WriteLine("Address: " + person2.Address);
            Console.WriteLine("City: " + person2.City);
            Console.WriteLine("State: " + person2.State);
            Console.WriteLine("Zip: " + person2.Zip);
            Console.WriteLine("Phone Number: " + person2.PhoneNumber);
            Console.WriteLine("Email: " + person2.Email);
            Console.WriteLine("---------------------------------------");

        }
    }
}



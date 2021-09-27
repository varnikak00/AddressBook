using System;

namespace AdressBookuc2
{
    class Program
    {
        static void Main(string[] args)
        {

            Datainput person = new Datainput();

            Console.WriteLine("First Name -");
            Console.WriteLine("First Name: ");
            person.FirstName = Console.ReadLine();

            Console.WriteLine("Last Name -");
            Console.WriteLine("Last Name: ");
            person.LastName = Console.ReadLine();

            Console.WriteLine("Address -");
            Console.WriteLine("Address: ");
            person.Address = Console.ReadLine();

            Console.WriteLine("City -");
            Console.WriteLine("City: ");
            person.City = Console.ReadLine();

            Console.WriteLine("State -");
            Console.WriteLine("State: ");
            person.State = Console.ReadLine();

            Console.WriteLine("Zip -");
            Console.WriteLine("Zip: ");
            person.Zip = Console.ReadLine();

            Console.WriteLine("Phone Number -");
            Console.WriteLine("Phone Number: ");
            person.PhoneNumber = Console.ReadLine();

            Console.WriteLine("Email -");
            Console.WriteLine("Email: ");
            person.Email = Console.ReadLine();

            Program.People.Add(person);
        }
    }
}

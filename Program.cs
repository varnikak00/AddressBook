using System;
using System.Collections.Generic;

namespace AddressBook
{
    class Program
    {
        static public string Firstname, Lastname, Address, City, State, Email;
        static public int zipNo;
        static public long Phonenumber;
        static public IDictionary<string, Contact> addressBook = new Dictionary<string, Contact>();
        private void takeInput()
        {
            Console.WriteLine("Enter values according Firstname, Lastname, Address, City, State, Email");
            Firstname = Console.ReadLine();
            Lastname = Console.ReadLine();
            Address = Console.ReadLine();
            City = Console.ReadLine();
            State = Console.ReadLine();
            Email = Console.ReadLine();
            Console.WriteLine("Zip Number, Phone number");
            zipNo = int.Parse(Console.ReadLine());
            Phonenumber = long.Parse(Console.ReadLine());
        }
        void displayAddressBook()
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.firstname, kvp.Value.lastname);
                Console.WriteLine("Address :{0},{1},{2},{3}", kvp.Value.address, kvp.Value.City, kvp.Value.zipNo, kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.Phonenumber);
                Console.WriteLine();
            }
        }
        void updateRecord()
        {
            Console.WriteLine("Do you want to edit name. Then type 1 or else 0");
            int choice = int.Parse(Console.ReadLine());
            if (choice == 1)
            {
                Console.WriteLine("Type key");
                string key = Console.ReadLine();
                Console.WriteLine("Type name currently seen");
                string currentName = Console.ReadLine();
                Console.WriteLine("Type name you want");
                Program p = new Program();
                string editToName = Console.ReadLine();
                if (p.editNameInAddressBook(key, currentName, editToName))
                {
                    Console.WriteLine("Successfully name updated");
                    p.displayAddressBook();
                }
            }
        }
        void deleteRecord()
        {
            Console.WriteLine("Enter key you want to delete");
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key + "  " + kvp.Value.firstname);
            }
            Console.WriteLine("Enter key and first name");
            string keyName, firstname;
            keyName = Console.ReadLine();
            firstname = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(keyName))
                {
                    if (kvp.Value.firstname.Equals(firstname))
                    {
                        addressBook.Remove(kvp.Key);
                    }
                }
            }
        }
        bool editNameInAddressBook(string key, string currentName, string editToName)
        {
            foreach(KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(key))
                {
                    if (kvp.Value.firstname.Equals(currentName))
                    {
                        kvp.Value.firstname = editToName;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Check displayed name spelling");
                    }
                }
                else
                {
                    Console.WriteLine("Error 404: Key not found! check key name.");
                }
            }
            return false;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Address Book");
            Program p = new Program();
            //Enter record & display all record
            for(int i = 1; i < 3; i++)
            {
                string temp = DateTime.Now.ToString("yyyy-MM-dd");  
                p.takeInput();
                Contact contact = new Contact(Firstname, Lastname, Address, City, State, Email, Phonenumber, zipNo);
                temp = Firstname + temp;
                addressBook.Add(temp, contact);
            }
            p.displayAddressBook();

            //Editing record based on key and firstname
            //p.updateRecord();

            //Delete method invokation
            p.deleteRecord();
            p.displayAddressBook();
        }
    }
}

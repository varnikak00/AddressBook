﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AddressBookIoFile
{
    internal class CRUDoperationOnContact
    {
        private const string FILEPATH = @"F:\JSON\Addressbook.txt";

        private readonly Dictionary<string, string> PersonAndCity = new Dictionary<string, string>();
        private readonly Dictionary<string, string> PersonAndState = new Dictionary<string, string>();
        /// <summary>
        /// Take input from user
        /// </summary>
        /// <param name="addressBook"></param>
        internal void takeInput(IDictionary<string, Contact> addressBook)
        {
            string Firstname, Lastname, Address, City, State, Email;
            int zipNo;
            long Phonenumber;

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
            Contact contact = new Contact();
            contact.Firstname = Firstname;
            contact.Lastname = Lastname;
            contact.Address = Address;
            contact.City = City;
            contact.State = State;
            contact.Email = Email;
            contact.Zipno = zipNo;
            contact.PhoneNo = Phonenumber;
            string temp = DateTime.Now.ToString("yyyy-MM-dd");
            temp = Firstname + temp;

            var tempAddressBook = addressBook;
            bool result = true;
            //Checking for duplicate person 
            foreach (KeyValuePair<string, Contact> kvp in tempAddressBook)
            {
                if (kvp.Value.Firstname == contact.Firstname && kvp.Value.Lastname == contact.Lastname)
                {
                    Console.WriteLine("Person {0} {1} is alread present in address book record", contact.Firstname, contact.Lastname);

                    result = false;
                }
            }

            string addressRecord = "Key :" + temp + "\nPerson Name : " + Firstname + " " + Lastname + "\nAddress : " + Address + "," + City + "," + State + "," + zipNo + "\nPhone number : " + Phonenumber;

            if (result)
            {
                using StreamWriter sw = File.AppendText(FILEPATH);
                sw.WriteLine(addressRecord);
                sw.Close();
                addressBook.Add(temp, contact);

            }
            //Adding value to person and city
            string fullname = Firstname + " " + Lastname;
            PersonAndCity.Add(fullname, City);
            PersonAndState.Add(fullname, State);
        }
        /// <summary>
        /// Display each record from AdressBook
        /// </summary>
        /// <param name="addressBook"></param>
        internal void displayAddressBook(IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key);
                Console.WriteLine("Name :{0} {1}", kvp.Value.Firstname, kvp.Value.Lastname);
                Console.WriteLine("Address :{0},{1},{2},{3}", kvp.Value.Address, kvp.Value.City, kvp.Value.Zipno, kvp.Value.State);
                Console.WriteLine("Phone number: {0}", kvp.Value.PhoneNo);
                Console.WriteLine();

            }
        }
        /// <summary>
        /// Display count of according to city name or state name
        /// </summary>
        /// <param name="addressBook"></param>
        internal void DisplayCountOfPersonAccordingToCityORState(IDictionary<string, Contact> addressBook)
        {
            Console.WriteLine("Select option number \n1. City\n 2. State");
            int opt = int.Parse(Console.ReadLine());
            int count = 0;
            switch (opt)
            {
                case 1:
                    Console.WriteLine("Enter city name");
                    string city = Console.ReadLine();
                    var result = addressBook.Where(p => p.Value.City.Equals(city));
                    foreach (var i in result)
                    {
                        count++;
                    }
                    Console.WriteLine("{0} count is {1}", city, count);
                    break;
                case 2:
                    Console.WriteLine("Enter city name");
                    string state = Console.ReadLine();
                    var result1 = addressBook.Where(p => p.Value.State.Equals(state));
                    foreach (var i in result1)
                    {
                        count++;
                    }
                    Console.WriteLine("{0} count is {1}", state, count);
                    break;

            }

        }
        /// <summary>
        /// Display full name person and city
        /// </summary>
        internal void DisplayPersonAndCity()
        {
            Console.WriteLine("Enter city name");
            string name = Console.ReadLine();
            var result = PersonAndCity.Where(p => p.Value.Equals(name));
            foreach (var i in result)
            {
                Console.WriteLine("key : {0}\tcity names : {1}", i.Key, i.Value);
            }
        }
        /// <summary>
        /// Display full name person and state
        /// </summary>
        internal void DisplayPersonAndState()
        {
            Console.WriteLine("Enter state name");
            string name = Console.ReadLine();
            var result = PersonAndState.Where(p => p.Value.Equals(name));
            foreach (var i in result)
            {
                Console.WriteLine("key : {0}\tstate names : {1}", i.Key, i.Value);
            }
        }
        /// <summary>
        /// Display person name using either state or city name.
        /// </summary>
        /// <param name="addressBook"></param>
        internal void DisplayPersonName(IDictionary<string, Contact> addressBook)
        {
            Console.WriteLine("Enter state name or city name");
            string name = Console.ReadLine();
            var result = addressBook.Where(p => p.Value.City == name || p.Value.State == name);
            foreach (var i in result)
            {
                Console.WriteLine("key : {0}\tPerson names : {1} {2} ", i.Key, i.Value.Firstname, i.Value.Lastname);
            }
        }

        /// <summary>
        /// update name value with the help of key
        /// </summary>
        /// <param name="addressBook"></param>
        internal void updateRecord(IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key + "\t" + kvp.Value.Firstname);
            }
            Console.WriteLine("Type key");
            string key = Console.ReadLine();
            Console.WriteLine("Type name currently seen");
            string currentName = Console.ReadLine();
            Console.WriteLine("Type name you want");
            string editToName = Console.ReadLine();
            CRUDoperationOnContact crud = new CRUDoperationOnContact();
            if (crud.editNameInAddressBook(key, currentName, editToName, addressBook))
            {
                Console.WriteLine("Successfully name updated");
                // string msg = "Successfully name updated from " + currentName + " to" + editToName;

                crud.displayAddressBook(addressBook);
            }
        }
        /// <summary>
        /// delete record using key
        /// </summary>
        /// <param name="addressBook"></param>
        internal void deleteRecord(IDictionary<string, Contact> addressBook)
        {
            Console.WriteLine("Enter key you want to delete");
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                Console.WriteLine(kvp.Key + "  " + kvp.Value.Firstname);
            }
            Console.WriteLine("Enter key and first name");
            string keyName, firstname;
            keyName = Console.ReadLine();
            firstname = Console.ReadLine();
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(keyName))
                {
                    if (kvp.Value.Firstname.Equals(firstname))
                    {
                        addressBook.Remove(kvp.Key);
                        //  string msg = "Successfully name updated from " + kvp.Key.ToString();
                        //  nlog.LogInfo(msg);
                    }
                }
            }
        }

        /// <summary>
        /// Edit name of person using key
        /// </summary>
        /// <param name="key"></param>
        /// <param name="currentName"></param>
        /// <param name="editToName"></param>
        /// <param name="addressBook"></param>
        /// <returns></returns>
        internal bool editNameInAddressBook(string key, string currentName, string editToName, IDictionary<string, Contact> addressBook)
        {
            foreach (KeyValuePair<string, Contact> kvp in addressBook)
            {
                if (kvp.Key.Equals(key))
                {
                    if (kvp.Value.Firstname.Equals(currentName))
                    {
                        kvp.Value.Firstname = editToName;
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("Check displayed name spelling");
                    }
                }
                else
                {
                    Console.WriteLine("Error : Key not found! check key name.");
                }
            }
            return false;
        }

        public void ReadFileUsingStreamReader()
        {
            using StreamReader sr = File.OpenText(FILEPATH);
            string temp = "";
            while ((temp = sr.ReadLine()) != null)
            {
                Console.WriteLine(temp);
            }
            sr.Close();
        }
    }
}
    
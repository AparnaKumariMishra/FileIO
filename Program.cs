using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using System.Text;
using System.Threading.Tasks;

namespace Insert_And_Display_Csv
{
    public class Person
    {
        //Propery Declear   
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int zipcode { get; set; }
        public long phoneNumber { get; set; }
    }
    class File1
    {
        static void Main(string[] args)
        {
            List<Person> list = new List<Person>();
            string path = @"C:\Users\Dell\source\repos\FileIoProblemsolution\FileIoProblemUsingCSV\TextFile1.cvs";
            Console.Write("How many Contact You Have To Add:");
            int n = int.Parse(Console.ReadLine());
            for (int i = 1; i <= n; i++)
            {
                Person obj = new Person();
                //Accepting Details From User
                Console.WriteLine("Enter Details For " + i + " Contact");
                Console.Write("Enter First Name:");
                obj.firstname = Console.ReadLine();
                Console.Write("Enter Last Name:");
                obj.lastname = Console.ReadLine();
                Console.Write("Enter Address:");
                obj.address = Console.ReadLine();
                Console.Write("Enter City:");
                obj.city = Console.ReadLine();
                Console.Write("Enter State:");
                obj.state = Console.ReadLine();
                Console.Write("Enter ZipCode:");
                obj.zipcode = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter Mobile Number:");
                obj.phoneNumber = Convert.ToInt64(Console.ReadLine());

                //Adding Details to list
                list.Add(obj);
                Console.WriteLine("Contact Added");
                Console.WriteLine("\n");
            }
            //writing list data in file given using third party library
            using (var writer = new StreamWriter(path))
            using (var csvwriter = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csvwriter.WriteRecords(list);
            }
            Console.WriteLine("Data Inside File ");
            //displaying data in file using third party library
            using (var reader = new StreamReader(path))
            using (var csvreader = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var person = csvreader.GetRecords<Person>().ToList();
                foreach (Person data in person)
                {
                    Console.WriteLine("*************Contact Details****************");
                    Console.WriteLine($"Name of person         : {data.firstname} {data.lastname}");
                    Console.WriteLine($"Address of person is   : {data.address}");
                    Console.WriteLine($"City                   : {data.city}");
                    Console.WriteLine($"State                  : {data.state}");
                    Console.WriteLine($"Zip                    : {data.zipcode}");
                    Console.WriteLine($"Phone Number of person : {data.phoneNumber}");
                    Console.WriteLine("\n");
                }
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CSVFileDemo
{
    public class CsvHandler
    {
        public static void implementCSVDataHandling()
        {
            string importFilePath = @"C:\Users\gokul\source\repos\CSVFileDemo/address1";
            using (var reader = new StreamReader(importFilePath))
            using(var csv=new CsvReader(reader,CaltureInfo.InvariantCalcultrue))
            { 
            var record = csv.GetRecords<AddressDemo>().ToList();
                Console.WriteLine("Read dats succesfuly from Address.csv");
                foreach (AddressData addressData in records)
                {
                    Console.WriteLine(addressData.firstname);
                    Console.WriteLine(addressData.lastnsme);
                    Console.WriteLine(addressData.address);
                    Console.WriteLine(addressData.city);
                    Console.WriteLine(addressData.state);
                    Console.WriteLine(addressData.Code);
                }
                Console.WriteLine("*********************");
                using (var writer = new StreamWriter(exportFilePath))
                    using(var csvExport=new csvwriter(writer,cultureInof.InvariantCulture))
                {
                    csvExport.writeRecords(record);
                }

               }
        }
            
    }
}

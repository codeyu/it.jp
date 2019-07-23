using System;
using System.Collections.Generic;
using System.Linq;
namespace tool
{
    class Program
    {
        static void Main(string[] args)
        {
            var lst = new List<string>();
            string[] lines =  System.IO.File.ReadAllLines(@"..\it.jp.txt");
            foreach (string line in lines)
            {
                var tabs = line.Split("     ").Select(x=>x.Trim()).ToList();
                if(tabs[0].Trim() == "id")
                {
                    var tableHead = string.Join('|', tabs);
                    lst.Add(tableHead);
                    Console.WriteLine(tableHead);
                    lst.Add("--- | --- | --- | ---");
                    Console.WriteLine("--- | --- | --- | ---");
                }
                else
                {
                    var row = string.Join('|', tabs);
                    lst.Add(row);
                    Console.WriteLine(row);
                }
                
            }
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace tool
{
    class Program
    {
        const string fileName = "README.md";
        static void Main(string[] args)
        {
            var lst = new List<string>();
            //string dir = System.Environment.CurrentDirectory;
            //string dir1 = Path.GetFullPath("..");
            //string dir2 = Path.GetFullPath(@"..//..//..//..");
            string[] lines =  System.IO.File.ReadAllLines(@"..\..\..\..\it.jp.txt");
            var count = 0;
            foreach (string line in lines)
            {
                if(string.IsNullOrEmpty(line.Trim()))
                {
                    continue;
                }
                var tabs = System.Text.RegularExpressions.Regex.Split(line, "\\s{2,}");
                if(count == 0)
                {
                    var tableHead = string.Join('|', tabs);
                    lst.Add(tableHead);
                    Console.WriteLine(tableHead);
                    lst.Add("--- | --- | --- | ---");
                    Console.WriteLine("--- | --- | --- | ---");
                }
                else
                {
                    tabs = FixedArrLengthFor4(tabs).ToArray();
                    var row = string.Join('|', tabs);
                    lst.Add(row);
                    Console.WriteLine(row);
                }
                count++;
            }
            lst.Add($"## 共{count}个字");
            using (StreamWriter outputFile = new StreamWriter($@"..\..\..\..\{fileName}", true))
            {
                foreach (string line in lst)
                {
                    outputFile.WriteLine(line);
                }
                    
            }
            Console.WriteLine($"共{count}个字");
            Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
        static IEnumerable<string> FixedArrLengthFor4(string[] input)
        {
            switch(input.Length)
            {
                case 1:
                    return input.Concat(new[] { " ", " ", " " });
                case 2:
                    return input.Concat(new[] { " ", " ",});
                case 3:
                    return input.Concat(new[] { " ", });
                case 4:
                    return input;
                case 5:
                    return new[] { input[0], $"{input[1]}({input[2]})", input[3], input[4] };
                default:
                    return new[] { input[0], $"{input[1]}({input[2]})", input[3] }.Append(string.Join("", input.Skip(4)));
            }
        }
    }
}

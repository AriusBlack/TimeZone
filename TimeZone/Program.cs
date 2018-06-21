using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeZone
{
    class Program
    {
        

        static void Main(string[] args)
        {
            Dictionary<string, string[]> timeZone = new Dictionary<string, string[]>();

            string[] lines = System.IO.File.ReadAllLines(@"F:\WORK\Programming\C#\VisualC#\TimeZone\TimeZone\TimeZone\Assets\timeZoneList.txt");

            int index = 0;

            // Starting at -11 copy lines from timeZoneList to dictionary
            foreach(string line in lines)
            {
                if (line.Length != 0)
                {
                    string holder = line;
                    string[] value2 = System.Text.RegularExpressions.Regex.Split(holder, @" +");
                    IEnumerable <string> s = value2.ToArray();
                    s = s.Skip(2);

                    if (timeZone.ContainsKey(value2[0]))
                    {
                        timeZone[value2[0]] = s.ToArray();
                        index++;
                    }
                    else
                    {
                        timeZone.Add(value2[0], value2);
                    }
                }

            }
            foreach(string key in timeZone.Keys)
            {
                System.Console.WriteLine(key);
            }

            foreach (string[] value in timeZone.Values)
            {
                foreach(string city in value)
                {
                    System.Console.WriteLine(city);
                }
                
            }
            string b = Console.ReadLine();

            


            // zone object  with name of big cities and + or - GMT
            // dict key GMT time : string list of cities
            // check for 


        }
    }
}

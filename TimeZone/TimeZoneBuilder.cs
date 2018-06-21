using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TimeZone
{
    class Builder
    {      
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> timeZone = new Dictionary<string, List<string>>();

            string[] lines = System.IO.File.ReadAllLines
                (@"F:\WORK\Programming\C#\VisualC#\TimeZone\TimeZone\TimeZone\Assets\timeZoneList.txt");

            foreach(string line in lines)
            {
                if (line.Length != 0)
                {
                    string holder = line;
                    string[] splitLine = System.Text.RegularExpressions.Regex.Split(holder, @"\s{2,}");
                    List<string> listedLine = splitLine.ToList<string>();
                    List<string> values = listedLine.Skip(3).ToList();
                    List<string> existing;
                    if (!timeZone.TryGetValue(splitLine[0], out existing))
                    {
                        existing = new List<string>();
                        if (values.Contains(""))
                        {
                            continue;
                        }
                        else
                        {
                            timeZone[listedLine[0]] = listedLine.Skip(3).ToList();
                        }
                    }
                    else
                    {
                        if (values.Contains(""))
                        {
                            continue;
                        }
                        else
                        {
                            timeZone[splitLine[0]].AddRange(listedLine.Skip(3).ToList());
                            IEnumerable<string> previousLine = listedLine;
                        }
                    }
                }
            }
            foreach (string key in timeZone.Keys)
            {
                System.Console.WriteLine(key.ToString());
                foreach (string value in timeZone[key])
                {
                    System.Console.WriteLine(value.ToString());
                }

            }
            string b = System.Console.ReadLine();
            Viewer view = new Viewer(timeZone, 0);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DictionaryComplex
{
    class Program
    {

 
        static void Main(string[] args)
        {
            var locations = new Dictionary<string, int>()
            {
                { "test1", 4},
                { "test3", 9},
                { "test2", 1},
                { "test5", 2},
                { "test9", 3}
            };

            var elements = locations;
            // To get max value key name in dictionary
            var guidForMaxDate = locations
                .FirstOrDefault(x => x.Value == locations.Values.Max());

            Console.WriteLine(guidForMaxDate);
        }
    }
}

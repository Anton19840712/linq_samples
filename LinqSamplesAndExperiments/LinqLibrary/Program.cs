using System;
using System.Linq;

namespace LinqLibrary
{
    internal class Program
    {
        private static void Main()
        {
            //if you need performance - for is the best one. 

            var names = new[] { "Antonio", "Irina", "Victoria", "Elena", "Marina", "Selena", "Minerva" };

            var resultQuickAndTwiceMoreMemory73Allocated = names.Count(x => x.Contains("a"));

            var resultSlowButLessMemory40Allocated = names.Count(x => x.Contains("a"));
        }
    }
}
 
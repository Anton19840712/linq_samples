using System;
using System.Collections.Generic;
using System.Linq;

//KeyValuePair
//ToList()
//Zip

namespace ThinkingInLinq
{
    class Program
    {
        static void Main(string[] args)
        {

            var lst1  = new List<int> { 1, 3, 3, 4, 5, 6, 7, 878, 9, 90 };

            var lst2 = new List<int> { 3,3,5,3,3,3,3,3,52 };

            lst1.Union(lst2).Distinct().OrderBy(x => x).ToList().ForEach(x=>Console.WriteLine(x));


            //Sample for KeyValuePair -------------------------------- like dictionaries
            //var length = 9;
            //Enumerable.Range(1,length)
            //    .Select(x=>new KeyValuePair<int,string>(
            //        x, $"Antonio - " + x)).ToList().ForEach(x=>Console.WriteLine("Key: {0}, Value: {1}", x.Key, x.Value));

            //Sample  --------------------------------
            //int[] array = {3, 4, 3, 2, 3, -1, 3, 3};//O do not know, but with another set this does not work

            //var element = array.ToLookup(a => a).First(a => a.Count() > array.Length/2).Key;

            //Console.WriteLine(element);

            //Sample select anonymous type --------------------------------
            //var enumerable = Enumerable.Range(2, 10).Select(c => new { Name = $"Antonio " + c, Age = c });

            //foreach (var item in enumerable)
            //{
            //    Console.WriteLine(item);
            //}
            //or

            //Enumerable.Range(2, 10).Select(c => new { Name = $"Antonio " + c, Age = c }).ToList().ForEach(x=>Console.WriteLine(x));



            //Sample --------------------------------
            //var elements =Enumerable.Range(2, 10);

            //foreach (var item in elements)
            //{
            //    Console.WriteLine(item); //2 - 11
            //}

            //1 Compare each element of one collection with each element from another collection  by index.
            //--------------------------------
            //var elements1 = new List<int> {1, 2, 3, 4, 5, 6, 76, 7, 8, 9, 4, 5, 5, 5};
            //var elements2 = new List<int> {4, 2, 2, 3, 4, 5, 5, 62, 345623, 46, 6, 7, 8, 3456};

            //var result = elements1.Zip(elements2, Math.Max);

            //foreach (var item in result)
            //{
            //    Console.WriteLine(item);
            //}



        }
    }
}

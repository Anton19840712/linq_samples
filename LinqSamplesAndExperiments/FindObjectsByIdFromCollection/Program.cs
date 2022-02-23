using LinqLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FindObjectsByIdFromCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            var collectionOfIds = new List<int> { 5, 6, 7};

            var elements  = ListManager.LoadSampleIdData();

            var newOneCollection = new List<PersonWithId>();

            //var resultsAny = elements.Where(p => collectionOfIds.Any(p2 => p2 != p.Id));// не имеет смысла, выведет все из второй коллекции, все 7 айтемов\объектов

            //var results2 = elements.Where(p => !collectionOfIds.All(p2 => p2 == p.Id)).ToList(); // не имеет смысла, выведет всех


            var resultsAny 
                = elements.Where(p => collectionOfIds.Any(p2 => p2 == p.Id)); // те, которые есть

            var results = 
                elements.Where(p => collectionOfIds.All(p2 => p2 == p.Id)).ToList(); // те, которых нет

            var resultsContains//== resultsAny
                = elements.Where(p => collectionOfIds.Contains(p.Id)); // те, которые есть == resultsAny



            foreach (var item in resultsAny)
            {
                Console.WriteLine($"{item.Id}: {item.FullName}");
            }

            Console.WriteLine("==================");

            foreach (var item in results)
            {
                Console.WriteLine($"{item.Id}: {item.FullName}");
            }

            Console.WriteLine("==================");

            foreach (var item in resultsContains)
            {
                Console.WriteLine($"{item.Id}: {item.FullName}");
            }
        }
    }
}

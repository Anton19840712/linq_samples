using System;
using System.Collections.Generic;
using System.Linq;

//LOOKUP:
//1) Target field to search.
//2) Target key to search in this field.

namespace LinqLookUp
{
    internal class Program
    {
        private static void Main()
        {
            //1) for the birth date as an int type with actor class sample...:
            //field where to run/search...:
            var lookupResult = Actor.GetActors().ToLookup(k => k.BirthYear); //Actor.GetActors() = collection

            var actors = lookupResult[1964].ToList(); //creating the key
            //var actors = lookupResult[1964]

            actors.ForEach(a => Console.WriteLine("{0} {1}", a.FirstName, a.LastName));
            Console.WriteLine("-----------------------------------------");

            //2) for the birth date as an string type with actor2 class sample...:
            var lookup = Actor2.GetActors()
                .ToLookup(k => k.BirthYear, new MyLikeStringNumberComparer());

            var actorsList = lookup["0001964"];
            foreach (var a in actorsList) Console.WriteLine("{0} {1}", a.FirstName, a.LastName);
            Console.WriteLine("-----------------------------------------");


            //3
            var lookupFields = Actor.GetActors().ToLookup(k => k.BirthYear, a => $"{a.FirstName} {a.LastName}");

            var actorsCollection = lookupFields[1964];
            foreach (var actor in actorsCollection) Console.WriteLine("{0}", actor);


            //4

            var lookupElement = Actor2.GetActors().ToLookup(k => k.BirthYear,
                    a => $"{a.FirstName} {a.LastName}",
                    new MyLikeStringNumberComparer());

           var actorItems = lookupElement["0001964"];
            foreach (var actor in actorItems)
                Console.WriteLine("{0}", actor);
        }
    }
    public class Actor
    {
        public static Actor[] GetActors()
        {
            var actors = new Actor[] {
                new Actor { BirthYear = 1964, FirstName = "Kevin", LastName = "Reeves" },
                new Actor { BirthYear = 1968, FirstName = "Owen", LastName = "Wilson" },
                new Actor { BirthYear = 1960, FirstName = "James", LastName = "Spider" },
                new Actor { BirthYear = 1964, FirstName = "Sandra", LastName = "Bullock" },
            };

            return (actors);
        }

        public int BirthYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class Actor2
    {
        public static Actor2[] GetActors()
        {
            var actors2 = new Actor2[] {
                new Actor2 { BirthYear = "1964", FirstName = "Kevin", LastName = "Reeves" },
                new Actor2 { BirthYear = "1968", FirstName = "Owen", LastName = "Wilson" },
                new Actor2 { BirthYear = "1960", FirstName = "James", LastName = "Spider" },
                new Actor2 { BirthYear = "01964", FirstName = "Sandra", LastName = "Bullock" },
            };

            return (actors2);
        }

        public string BirthYear { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class MyLikeStringNumberComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return (int.Parse(x ?? throw new ArgumentNullException(nameof(x))) == int.Parse(y ?? throw new ArgumentNullException(nameof(y))));
        }

        public int GetHashCode(string obj)
        {
            return int.Parse(obj).ToString().GetHashCode();
        }
    }
}

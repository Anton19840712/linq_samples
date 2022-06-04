using Microsoft.Linq.Translations;
using System;
using System.Linq;

namespace LinqTranslations
{
	class Program
	{
		static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");

			var dbContext = new EntitiesContext();

			//var persons = dbContext.Persons.ToList().Where(e => e.FullName.Contains("da"));



			//var personsCompiled = dbContext.Persons
			//    .Where(e => e.FullName.Contains("da"))
			//    .GroupBy(e => e.PersonAge)
			//    .WithTranslations();

			//2) You need to pre-complile FullName
			DefaultTranslationOf<Person>
				.Property(e => e.FullName)
				.Is(e => e.FirstName + " " + e.LastName);

			//using translation map:
			//3) Then create map:
			var myTranslationMap = new TranslationMap();

			//Creating map objects for expression tree in coordination with its FirstName
			//So, if you are going to check among FullNames, you will take FirstName and LastName of this record:
			//4)
			myTranslationMap.Add<Person, string>(e => e.FullName, e => e.FirstName + " " + e.LastName);

			//Among those, whose name is Martin take 
			var results = dbContext.Persons
												.Where(e => e.FullName.Contains("Doris"))
												.WithTranslations(myTranslationMap) //IQueriable<Person>
												.ToList();

			foreach (var person in results)
			{
				Console.WriteLine(person.FullName);
			}
		}
	}
}

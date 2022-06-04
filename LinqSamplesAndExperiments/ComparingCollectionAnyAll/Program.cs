using System;
using System.Collections.Generic;
using System.Linq;

namespace ComparingCollectionAnyAll
{
	class Program
	{
		static void Main(string[] args)
		{
			var firstCollection = new List<int> {5, 6, 7, 32, 34, 3423, 2222, 21};

			var secondCollection = new List<int> {1, 6, 3, 19, 7};

			var resultsAny = firstCollection.Where(p => secondCollection.Any(p2 => p2 == p)); // те, которые есть и там и там

			var resultsAny2 = firstCollection.Where(p => !secondCollection.Any(p2 => p2 == p)); // те, которых нет из первой коллекции // 5, 32

			var resultsOne = firstCollection.Where(p => secondCollection.All(p2 => p2 != p)).ToList(); //те, которых нет из первой коллекции // 5, 32

			var resultsTwo = secondCollection.Where(p => firstCollection.All(p2 => p2 != p)).ToList(); //те, которых нет из второй коллекции // 1, 3, 19

			var results32 = secondCollection.Except(firstCollection).ToList(); //те, которых нет из второй коллекции в первой// 1, 3, 19

			var results34 = firstCollection.Except(secondCollection).ToList(); //те, которых нет из первой коллекции во второй // 5, 32// которые есть в только первой, но нет во второй

			var results334 = firstCollection.Intersect(secondCollection).ToList(); //те, которые есть и в первой и во второй// 6, 7
		}
	}
}

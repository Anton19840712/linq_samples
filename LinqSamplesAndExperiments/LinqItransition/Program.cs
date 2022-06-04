using System;
using System.Collections.Generic;
using System.Linq;


// var nameOfBook = books.GroupBy(p => p.Category).Select(b => new {Books = Books}).OrderBy(b => b.Books.Max())
//     .FirstOrDefault();
//books.GroupBy(book => book.Category)
//.Select(bookGroup => bookGroup
//.First(b => b.Name.Length == bookGroup.Max(book => book.Name.Length)))
//.Select(book => $"Category: {book.Category}, Id: {book.Id}, Name: {book.Name}")//++
//.ToList()
//.ForEach(Console.WriteLine);


//Books.OrderByDescending(c => c.Name.Length)
//.GroupBy(x => x.Category)
//.Select(x => x.First())
//.ToList()
//.ForEach(element => Console.WriteLine("{0} --> {1}", element.Category, element.Name));


//Books.OrderByDescending(x => x.Name.Length)
//.GroupBy(l => l.Category)
//.Select(m => m.First())
//.ToList()
//.ForEach(ff => Console.WriteLine($"Category: {ff.Category}, Id: {ff.Id}, Name: {ff.Name}"));

namespace LinqItransition
{
	public class Program
	{
		public enum Category
		{
			Novel = 1,
			Detective = 2,
			Fairytale = 3
		}

		public class Book
		{
			public int Id { get; set; }
			public string Name { get; set; }
			public Category Category { get; set; }
		}

		public static List<Book> Books { get; } = new List<Book>
		{
			new Book
			{
				Id = 1,
				Name = "Chicken Little",
				Category = Category.Fairytale
			},
			new Book
			{
				Id = 2,
				Name = "The Big Sleep",
				Category = Category.Detective
			},
			new Book
			{
				Id = 3,
				Name = "Robin Hood",
				Category = Category.Fairytale
			},
			new Book
			{
				Id = 4,
				Name = "Ulysses",
				Category = Category.Novel
			},
			new Book
			{
				Id = 5,
				Name = "Gone Girl",
				Category = Category.Detective
			},
			new Book
			{
				Id = 6,
				Name = "Lolita",
				Category = Category.Novel
			},
			new Book
			{
				Id = 7,
				Name = "1984",
				Category = Category.Novel
			}
		};

		public static void Main()
		{
			// Description:
			//   Given a list of books. Each book has a category, an ID and a name.
			//   You need to find a book with the largest name length in each category and show it in the console in next format:
			//   "Category: <book's category>, Id: <book's Id>, Name: <book's name>"
			ShowBooks(Books);
		}

		public static void ShowBooks(List<Book> books)
		{
			Books.OrderByDescending(x => x.Name.Length)
				.GroupBy(x => x.Category)
				.Distinct()
				.ToList()
				.ForEach(xm => Console.WriteLine($"Category: {xm.Key}, Id: {xm.Select(x => x.Id).First()}, Name: {xm.Select(x => x.Name).First()}"));

			Console.WriteLine("------------------");

			books
				.OrderByDescending(x => x.Name.Length)
				.GroupBy(f => f.Category)
				.Select(d => d.First())
				.ToList()
				.ForEach(cw => Console.WriteLine($"Category: {cw.Category}, Id: {cw.Id}, Name: {cw.Name}"));

			//Console.WriteLine("---");

			//books
			//    .OrderByDescending(x=>x.Name.Length)
			//    .ToLookup(x => x.Category)
			//    .ToList()
			//    .ForEach(cw => Console.WriteLine($"Category: {cw.First().Category}, Id: {cw.First().Id}, Name: {cw.First().Name}"));
		}
	}
}
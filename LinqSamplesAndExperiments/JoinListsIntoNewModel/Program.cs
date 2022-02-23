using System;
using System.Collections.Generic;
using System.Linq;

namespace JoinListsIntoNewModel
{
    public class Car
    {
        public int Id { get; set; }
        public int MadeByPersonId { get; set; }
        public string MakerCompany { get; set; }
        public int ModelOfYear { get; set; }
        public string Color { get; set; }
    }

    public class Person
    {
        public int Id { get; set; }
        public string PersonName { get; set; }
        public int YearOfProduction { get; set; }
    }

    public class UnitedFullModel : Person
    {
        //public IEnumerable<Car> CarsCollection { get; set; }
        public List<Car> CarsCollection { get; set; }
    }

    internal class Program
    {
        public static void Main()
        {
            var cars = new List<Car>
           {
               new Car { Id = 1, MadeByPersonId = 1, MakerCompany = "Honda", ModelOfYear = 2000, Color = "Black" },
               new Car { Id = 2, MadeByPersonId = 1, MakerCompany = "Suzuki", ModelOfYear = 1999, Color = "White" },
               new Car { Id = 4, MadeByPersonId = 3, MakerCompany = "Kia", ModelOfYear = 2121, Color = "Blue" },
               new Car { Id = 3, MadeByPersonId = 1, MakerCompany = "Toyota", ModelOfYear = 1988, Color = "Green" }
           };



            var persons = new List<Person>
           {
               new Person {Id = 4, PersonName = "Tim", YearOfProduction = 1998},
               new Person {Id = 3, PersonName = "John", YearOfProduction = 2021},
               new Person {Id = 1, PersonName = "Anton", YearOfProduction = 1991 }
           };

            //var elements = cars.ToLookup(s => s.MadeByPersonId);

            var fullElements = persons.Join(cars,
                                mad => mad.Id,
                                car => car.MadeByPersonId,
                                (mad, car) => new UnitedFullModel
                                {
                                    Id = mad.Id,
                                    PersonName = mad.PersonName,
                                    YearOfProduction = mad.YearOfProduction
                                }).ToList();

            //var query = persons.GroupJoin(cars,
            //                    person => person,
            //                    car => car.MadeByPersonId,
            //                    (person, сarCollection) =>
            //                        new UnitedFullModel
            //                        {
            //                            PersonName = person.PersonName,
            //                            //CarsCollection = сarCollection.Where(car => car.MadeByPersonId == person.Id)
            //                        });

            //======================================================================

            //works...:
            var byPerson = 

                persons//collection of persons

                    .GroupJoin(
                cars,//collection of cars

                person => person.Id,//by field from first collection

                car => car.MadeByPersonId,//by field from second collection

                (person, machines) => new UnitedFullModel()//node of person, plus collection of cars(should be another name, so as not to hide the same elements)
                {
                    Id = person.Id,
                    PersonName = person.PersonName,
                    YearOfProduction = person.YearOfProduction,
                    CarsCollection = machines.ToList()
                });


            //this also works...:

            var listOfUnitedModels = new List<UnitedFullModel>();

            foreach (var person in persons)
            {
                if (cars.Any(carr => carr.MadeByPersonId == person.Id))
                {
                    var listCollectionOfCars = new List<Car>();

                    var unitedModel = new UnitedFullModel();

                    foreach (var car in cars)
                    {
                        if (person.Id == car.MadeByPersonId)
                        {
                            listCollectionOfCars.Add(car);

                            unitedModel.Id = person.Id;
                            unitedModel.PersonName = person.PersonName;
                            unitedModel.YearOfProduction = person.YearOfProduction;
                            unitedModel.CarsCollection = listCollectionOfCars;
                        }
                    }

                    listOfUnitedModels.Add(unitedModel);
                }
            }

            var result = listOfUnitedModels;


            Console.ReadLine();

        }
    }
}

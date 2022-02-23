using System;
using System.Collections.Generic;

namespace LinqLibrary
{
    public class ListManager
    {
        public static List<Person> LoadSampleData()
        {
            List<Person> output = new List<Person>();

            output.Add(new Person { FirstName = "Tim", LastName = "Corey", Birthday = new DateTime(2015, 7, 20), YearsExperience = 1 });
            output.Add(new Person { FirstName = "Joe", LastName = "Smith", Birthday = new DateTime(1999, 7, 20), YearsExperience = 2 });
            output.Add(new Person { FirstName = "Pedro", LastName = "Storm", Birthday = new DateTime(2015, 7, 20), YearsExperience = 1 });
            output.Add(new Person { FirstName = "Sue", LastName = "Gustavo", Birthday = new DateTime(2015, 7, 20), YearsExperience = 27 });
            output.Add(new Person { FirstName = "Sara", LastName = "Jones", Birthday = new DateTime(1999, 7, 20), YearsExperience = 4 });
            output.Add(new Person { FirstName = "Jimmy", LastName = "Doe", Birthday = new DateTime(2015, 7, 20), YearsExperience = 10 });
            output.Add(new Person { FirstName = "Mary", LastName = "Martins", Birthday = new DateTime(1970, 7, 20), YearsExperience = 20 });

            return output;
        }

        public static List<PersonWithId> LoadSampleIdData()
        {
            List<PersonWithId> output = new List<PersonWithId>();

            output.Add(new PersonWithId { Id=1, FirstName = "Tim", LastName = "Corey", Birthday = new DateTime(2015, 7, 20), YearsExperience = 1 });
            output.Add(new PersonWithId { Id=2, FirstName = "Joe", LastName = "Smith", Birthday = new DateTime(1999, 7, 20), YearsExperience = 2 });
            output.Add(new PersonWithId { Id=3, FirstName = "Pedro", LastName = "Storm", Birthday = new DateTime(2015, 7, 20), YearsExperience = 1 });
            output.Add(new PersonWithId { Id=4, FirstName = "Sue", LastName = "Gustavo", Birthday = new DateTime(2015, 7, 20), YearsExperience = 27 });
            output.Add(new PersonWithId { Id=5, FirstName = "Sara", LastName = "Jones", Birthday = new DateTime(1999, 7, 20), YearsExperience = 4 });
            output.Add(new PersonWithId { Id=6, FirstName = "Jimmy", LastName = "Doe", Birthday = new DateTime(2015, 7, 20), YearsExperience = 10 });
            output.Add(new PersonWithId { Id=7, FirstName = "Mary", LastName = "Martins", Birthday = new DateTime(1970, 7, 20), YearsExperience = 20 });

            return output;
        }
    }
}

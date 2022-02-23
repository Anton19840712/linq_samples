using System.Reflection;
using Microsoft.Linq.Translations;

namespace LinqTranslations
{
    public partial class Person
    {
        //public string FullName => FirstName + " " + LastName; //with IEnumerable

        //1) Create branch to be precompiled in the future
        public string FullName => DefaultTranslationOf<Person>.Evaluate<string>(this, MethodBase.GetCurrentMethod());//wit
    }

    public partial class Person
    {
        public long PersonId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int PersonAge { get; set; }
    }
}
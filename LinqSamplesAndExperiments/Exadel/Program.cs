using System;
using System.Collections.Generic;
using System.Linq;



//var firstUser = users.Select(x => x.Roles).FirstOrDefault();

//var secondUser = users.Select(x => x.Roles).LastOrDefault();

//var elements = firstUser?.Concat(secondUser).Distinct();

//var elements2 = firstUser?.Except(secondUser);

//var elements3 = secondUser?.Except(firstUser);

//var keys = firstUser?.Select(x => x.RoleName).ToList();



//Вывести уникальные роли

//users
//    .SelectMany(x => x.Roles)
//    .Distinct()
//    .ToList()
//    .ForEach(x=>Console.WriteLine(x.RoleName));


//users.SelectMany(x => x.Roles).Distinct().ToList().ForEach(x => Console.WriteLine(x.RoleName));



//var res = users.SelectMany(s => s.Roles)
//.GroupBy(ss => ss.RoleName)
//.Where(sss => sss.Count() > 1)
//.Select(f => f.Key)
//.ToList();

namespace Exadel
{
    class Program
    {
        static void Main(string[] args)
        {


            var roleA = new Role { RoleName = "RoleA" };
            var roleB = new Role { RoleName = "RoleB" };
            var roleC = new Role { RoleName = "RoleC" };
            var roleD = new Role { RoleName = "RoleD" };
            var roleFf = new Role { RoleName = "roleFf" };


            var users = new List<User>()
            {
                new User { UserName = "User1", Roles = new List<Role> { roleA, roleB, roleC } },
                new User { UserName = "User1", Roles = new List<Role> { roleA, roleB, roleD, roleFf } }
            };

            //here:



        }

    }

    public class User
    {
        public string UserName { get; set; }
        public IList<Role> Roles { get; set; }
    }

    public class Role
    {
        public string RoleName { get; set; }
    }


}

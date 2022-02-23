//1:Chunk
var names = new[] { "Antonio", "Irina", "Victoria", "Elena", "Marina", "Selena", "Minerva" };

var chunked = names.Chunk(3); // this method cuts and packs elements in an individual arrays

Console.WriteLine(chunked.GetType().Name);//<ChunkIterator>d__65`1


foreach (var item in chunked)
{
    Console.WriteLine(item[0]); // from each array it takes the first one value
    //Antonio
    //Elena
    //Minerva
}

Console.WriteLine();

//2:Zip
var names1 = new[] { "Antonio", "Irina", "Victoria", "Elena", "Marina", "Selena", "Minerva" };
var ages = new[] { 28, 23, 24, 23, 34, 34, 23 };
var yearsOfExperience = new[] { 10, 5, 3};

IEnumerable<(string Name, int Age, int yearsOfExp)> zipvar = names.Zip(ages, yearsOfExperience);
foreach (var item in zipvar)
{
    Console.WriteLine(item);
    //only 3 pairs:
    //(Antonio, 28, 10)
    //(Irina, 23, 5)
    //(Victoria, 24, 3)
}

//3:Minby, Maxby == orderby + min == top one
var family = new[]
{
    new  FamilyMember("Antonio", 28),
    new  FamilyMember("Irina", 28),
    new  FamilyMember("Marina", 28),
};

//Prev style:
var youngest = family.OrderBy(x => x.Age).First();
var oldest = family.OrderByDescending(x => x.Age).First();

//Current style:

var youngestN = family.MinBy(x => x.Age);
var oldestN = family.MaxBy(x => x.Age);


//4: ^

Console.WriteLine();
var names2 = new[] { "Antonio", "Irina", "Victoria", "Elena", "Marina", "Selena", "Minerva" };

var nameNumberFiveFromTheEnd = names2.ElementAt(^5);

var skipTake = names2.Skip(1).Take(3);

var inBetweenTake = names2.Take(2..4); //Victoria, Elena

var takeFromTheEndSide = names2
    .Take(^3..); //"Marina", "Selena", "Minerva"

Console.WriteLine(nameNumberFiveFromTheEnd);

Console.WriteLine();

foreach (var item in skipTake)
{
    Console.WriteLine(item);
}

Console.WriteLine();

foreach (var item in inBetweenTake)
{
    Console.WriteLine(item);
}

Console.WriteLine();

foreach (var item in takeFromTheEndSide)
{
    Console.WriteLine(item);
}


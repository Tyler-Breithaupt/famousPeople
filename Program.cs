using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        IList<famousPeople> stemPeople = new List<famousPeople>() {
            new famousPeople() { Name= "Michael Faraday", BirthYear=1791, DeathYear=1867 },
            new famousPeople() { Name= "James Clerk Maxwell", BirthYear=1831, DeathYear=1879 },
            new famousPeople() { Name= "Marie Skłodowska Curie", BirthYear=1867, DeathYear=1934 },
            new famousPeople() { Name= "Katherine Johnson", BirthYear=1918, DeathYear=2020 },
            new famousPeople() { Name= "Jane C. Wright", BirthYear=1919, DeathYear=2013 },
            new famousPeople() { Name = "Tu YouYou", BirthYear= 1930 },
            new famousPeople() { Name = "Françoise Barré-Sinoussi", BirthYear=1947 },
            new famousPeople() { Name= "Lydia Villa-Komaroff", BirthYear=1947},
            new famousPeople() { Name= "Mae C. Jemison", BirthYear=1956},
            new famousPeople() { Name= "Stephen Hawking", BirthYear=1942, DeathYear=2018 },
            new famousPeople() { Name= "Tim Berners-Lee", BirthYear=1955 },
            new famousPeople() { Name= "Terence Tao", BirthYear=1975 },
            new famousPeople() { Name= "Florence Nightingale", BirthYear=1820, DeathYear=1910 },
            new famousPeople() { Name= "George Washington Carver", DeathYear=1943 },
            new famousPeople() { Name= "Frances Allen", BirthYear=1932, DeathYear=2020 },
            new famousPeople() { Name= "Bill Gates", BirthYear=1955 }
        };

        // Retrieve people with birthdates after 1900
        var queryA = from person in stemPeople
                     where person.BirthYear > 1900
                     select person;
        Console.WriteLine("People with birthdates after 1900:");
        DisplayResults(queryA);

        // Retrieve people who have two lowercase L's in their name
        var queryB = from person in stemPeople
                     where person.Name.ToLower().Count(c => c == 'l') >= 2
                     select person;
        Console.WriteLine("\nPeople with two lowercase L's in their name:");
        DisplayResults(queryB);

        // Count the number of people with birthdays after 1950
        var queryC = (from person in stemPeople
                      where person.BirthYear > 1950
                      select person).Count();
        Console.WriteLine($"\nNumber of people with birthdays after 1950: {queryC}");

        // Retrieve people with birth years between 1920 and 2000. Display their names and count the number of people in the list, then display the count.
        var queryD = from person in stemPeople
                     where person.BirthYear >= 1920 && person.BirthYear <= 2000
                     select person;
        Console.WriteLine("\nPeople with birth years between 1920 and 2000:");
        DisplayResultsWithCount(queryD);

        // Sort the list by BirthYear
        var queryE = from person in stemPeople
                     orderby person.BirthYear
                     select person;
        Console.WriteLine("\nList sorted by BirthYear:");
        DisplayResults(queryE);

        // Retrieve people with a death year after 1960 and before 2015, sort the list by name in ascending order.
        var queryF = from person in stemPeople
                     where person.DeathYear > 1960 && person.DeathYear < 2015
                     orderby person.Name ascending
                     select person;
        Console.WriteLine("\nPeople with a death year after 1960 and before 2015, sorted by name:");
        DisplayResults(queryF);
    }

    static void DisplayResults(IEnumerable<famousPeople> results)
    {
        foreach (var person in results)
        {
            Console.WriteLine($"{person.Name} - BirthYear: {person.BirthYear}, DeathYear: {person.DeathYear}");
        }
    }

    static void DisplayResultsWithCount(IEnumerable<famousPeople> results)
    {
        int count = 0;
        foreach (var person in results)
        {
            Console.WriteLine($"{person.Name} - BirthYear: {person.BirthYear}, DeathYear: {person.DeathYear}");
            count++;
        }
        Console.WriteLine($"Total Count: {count}");
    }
}

class famousPeople
{
    public string Name { get; set; }
    public int? BirthYear { get; set; } = null;
    public int? DeathYear { get; set; } = null;
}
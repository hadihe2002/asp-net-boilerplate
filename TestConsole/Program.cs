// using System.IdentityModel.Tokens.Jwt;
// using System.Text;
// using HadiDinner.Infrastructure.Authentication;

// var generator = new JwtTokenGenerator();

// var token = generator.GenerateToken(Guid.NewGuid(), "Hadi", "Hedayati");

// var tokenHandler = new JwtSecurityTokenHandler();
// var jwtToken = tokenHandler.ReadJwtToken(token);

// // Access claims
// foreach (var claim in jwtToken.Claims)
// {
//     Console.WriteLine($"{claim.Type}: {claim.Value}");
// }

using System.Numerics;
using System.Text.Json;

namespace TestConsole;

class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

struct Person2
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }

    public Person2(string firstName, string lastName, int age)
    {
        FirstName = firstName;
        LastName = lastName;
        Age = age;
    }
}

record Color
{
    public string Name { get; set; }
    public int Age { get; set; }
}

delegate int Multiply(int a, int b);

class Program
{
    public static void Main()
    {
        // static int Add(int x, int y)
        // {
        //     return x + y;
        // }
        //     public static int Mul(int a, int b) => a * b;
        // // Multiply a = Mul;

        static int Add(int x, int y)
        {
            return x + y;
        }
        Console.WriteLine(Add(2, 3));
    }

    public static void ClassAndStructs()
    {
        Person person1 = new(firstName: "Hadi", lastName: "Hedayati", age: 12);
        Person person2 = new(firstName: "Hadi", lastName: "Hedayati", age: 12);
        Person person8 = person1;

        PrintToConsole(JsonSerializer.Serialize(person1));
        PrintToConsole(person1.Equals(person2));
        PrintToConsole(person1 == person2);

        Person2 person3 = new("Hadi", "Hedayati", age: 22);
        Person2 person4 = person3;
        Person2 person5 = new("Hadi", "Hedayati", 22);

        PrintToConsole(ReferenceEquals(person3, person4));
        PrintToConsole(person3.Equals(person5));
        PrintToConsole(ReferenceEquals(person1, person8));

        Color color1 = new() { Name = "Color", Age = 12 };
        Color color2 = new() { Name = "Color", Age = 12 };

        PrintToConsole(color1 == color2);
        PrintToConsole(color1.Equals(color2));

        PrintToConsole(person1.ToString().GetHashCode());
        PrintToConsole(person2.ToString().GetHashCode());
        PrintToConsole(person3.ToString().GetHashCode());
        PrintToConsole(person5.ToString().GetHashCode());
    }

    public static void PrintToConsole(object obj)
    {
        Console.WriteLine(obj);
    }
}

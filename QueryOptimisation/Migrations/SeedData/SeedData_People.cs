using QueryOptimisation.Models;

namespace QueryOptimisation.Migrations.SeedData;

public static class SeedData_People
{
    public static List<Person> People => new()
    {
        new Person {
            UniqueId = Guid.Parse("01330659-88ee-4b4d-9504-798e86e4f1fb"),
            Name = "Joe Bloggs",
            Age = 31,
            Salary = 24000,
            DateCreated = DateTime.Now,
            JobTitle = "Junior Developer"
        },

        new Person {
            UniqueId = Guid.Parse("4b890223-a422-42b2-a518-fcbdd1550684"),
            Name = "Jane Doe",
            Age = 35,
            Salary = 35000,
            JobTitle = "Mid Tier Developer",
            DateCreated = DateTime.Now.AddDays(-200)
        }
    };
}
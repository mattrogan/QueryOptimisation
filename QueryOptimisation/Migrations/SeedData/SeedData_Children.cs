using QueryOptimisation.Models;

namespace QueryOptimisation.Migrations.SeedData;

public static class SeedData_Children
{
    public static List<Person> Children => new()
    {
        new Person {
            UniqueId = Guid.Parse("b2fec21a-40ee-4cb2-9167-91502e95db01"),
            Name = "Adam Bloggs",
            Age = 15,
            Salary = 0,
            DateCreated = DateTime.Now,
            ParentId = Guid.Parse("01330659-88ee-4b4d-9504-798e86e4f1fb"),
            JobTitle = ""
        },

        new Person {
            UniqueId = Guid.Parse("e3270438-8d96-41dd-afc1-8a9d7dfb1be4"),
            Name = "Johnny Bloggs",
            Age = 17,
            Salary = 0,
            DateCreated = DateTime.Now,
            ParentId = Guid.Parse("01330659-88ee-4b4d-9504-798e86e4f1fb"),
            JobTitle = ""
        },

        new Person {
            UniqueId = Guid.Parse("d9a5887e-602a-4cb0-b165-8ab0ab900430"),
            Name = "Sam Doe",
            Age = 8,
            Salary = 0,
            DateCreated = DateTime.Now,
            ParentId = Guid.Parse("4b890223-a422-42b2-a518-fcbdd1550684"),
            JobTitle = ""
        },

        new Person {
            UniqueId = Guid.Parse("b0b64c57-241b-4fa7-9df2-8a639b9f8382"),
            Name = "Mark Doe",
            Age = 11,
            Salary = 0,
            DateCreated = DateTime.Now,
            ParentId = Guid.Parse("4b890223-a422-42b2-a518-fcbdd1550684"),
            JobTitle = ""
        },

        new Person {
            UniqueId = Guid.Parse("eb8c7d70-4403-4ccc-801a-a3e9b7cb744d"),
            Name = "Will Doe",
            Age = 12,
            Salary = 0,
            DateCreated = DateTime.Now,
            ParentId = Guid.Parse("4b890223-a422-42b2-a518-fcbdd1550684"),
            JobTitle = ""
        }
    };
}
namespace QueryOptimisation.Models;

public class Person : BaseEntity
{
    public Person()
        : base()
    {
    }

    public int Age { get; set; }

    public string JobTitle { get; set; } = string.Empty;

    public int Salary { get; set; }

    public Guid? ParentId { get; set; }

    public Person? Parent { get; set; }

    public IEnumerable<Person> Children { get; set; } = new List<Person>();
}

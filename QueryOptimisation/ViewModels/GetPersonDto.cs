using System.Runtime.Serialization;
using QueryOptimisation.Models;

namespace QueryOptimisation.ViewModels;

[DataContract]
public class GetPersonDto
{
    public GetPersonDto()
    {
    }

    public GetPersonDto(Person person)
        : this()
    {
        Name = person.Name;
        Age = person.Age;
        NumChildren = person.Children.Count();
    }
    
    [DataMember(Name = "name")]
    public string Name { get; set; } = string.Empty;
    
    [DataMember(Name = "age")]
    public int Age { get; set; }

    [DataMember(Name = "children")]
    public int NumChildren { get; set; }
}
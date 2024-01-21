using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QueryOptimisation.Models;
using QueryOptimisation.ViewModels;

namespace QueryOptimisation.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PersonControllerWithSelect : ControllerBase
{
    private readonly DataContext ctx;

    public PersonControllerWithSelect(DataContext ctx)
    {
        this.ctx = ctx;
    }

    [HttpGet]
    public async Task<IActionResult> GetPeopleAsync()
        => Ok(ctx.Set<Person>().Include(nameof(Person.Children)).Select(x => new GetPersonDto
        {
            Name = x.Name,
            Age = x.Age,
            NumChildren = x.Children.Count()
        }));
}

[ApiController]
[Route("api/[controller]")]
public class PersonControllerWithConstructor : ControllerBase
{
    private readonly DataContext ctx;

    public PersonControllerWithConstructor(DataContext ctx)
    {
        this.ctx = ctx;
    }

    [HttpGet]
    public async Task<IActionResult> GetPeopleAsync() 
        => Ok(ctx.Set<Person>().Include(nameof(Person.Children)).Select(x => new GetPersonDto(x)));
}

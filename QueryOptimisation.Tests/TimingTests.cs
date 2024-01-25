using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QueryOptimisation.Controllers;
using QueryOptimisation.Models;

namespace QueryOptimisation.Tests;

[TestClass]
public class TimingTests
{
    private DataContext context;

    [TestInitialize]
    public void Initialise()
    {
        // Configure InMemory testing database
        var serviceProvider = new ServiceCollection()
            .AddDbContext<DataContext>(opts =>
                opts.UseSqlServer("Server=localhost,6666;Database=EfCoreQueryOptimisation_Test;User Id=sa;Password=Pass@word;"))
            .BuildServiceProvider();

        this.context = serviceProvider.GetRequiredService<DataContext>();

        if (this.context.Database.GetPendingMigrations().Any())
        {
            this.context.Database.Migrate();
        }
    }

    [TestCleanup]
    public void Cleanup()
    {
        this.context.Dispose();
    }
    
    [TestMethod]
    public async Task TestTimingOfEndpoints()
    {
        // Write time results to file in executing location
        var dir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var path = Path.Combine(dir, "results.csv");
        using var writer = new StreamWriter(path, false);

        // Add table headings
        writer.WriteLine($"Date,NumEntries,TimeTaken(ms),Method,FasterBy(ms)");

        // Repeat the test with a growing data set
        for (int i = 1; i <= 100; i++)
        {
            // Seed entities in the context
            var people = Enumerable.Range(0, i)
                .Select(x => new Person
                {
                    UniqueId = Guid.NewGuid(),
                    Name = $"Person on Iteration {x}",
                    Age = 123,
                    Salary = 456,
                    DateCreated = DateTime.Now,
                    JobTitle = "Test Dummy"
                })
            .AsEnumerable();

            await this.context.AddRangeAsync(people);
            await this.context.SaveChangesAsync();

            var numEntries = this.context.Set<Person>().Count();

            var selectSubject = new PersonControllerWithSelect(this.context);
            var ctorSubject = new PersonControllerWithConstructor(this.context);

            var selectTic = DateTimeOffset.UtcNow;
            var selectResult = await selectSubject.GetPeopleAsync();
            var selectToc = DateTimeOffset.UtcNow - selectTic;

            Assert.IsInstanceOfType(selectResult, typeof(OkObjectResult));

            var ctorTic = DateTimeOffset.UtcNow;
            var ctorResult = await ctorSubject.GetPeopleAsync();
            var ctorToc = DateTimeOffset.UtcNow - ctorTic;
            
            Assert.IsInstanceOfType(ctorResult, typeof(OkObjectResult));

            var diff = Math.Abs(ctorToc.TotalMilliseconds - selectToc.TotalMilliseconds);

            if (ctorToc < selectToc)
            {
                writer.WriteLine($"{DateTimeOffset.UtcNow},{numEntries},{ctorToc.TotalMilliseconds},Constructor,{diff}");
            }
            else
            {
                writer.WriteLine($"{DateTimeOffset.UtcNow},{numEntries},{selectToc.TotalMilliseconds},Select,{diff}");
            }
        }
    }
}
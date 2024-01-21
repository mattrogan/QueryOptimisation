using Microsoft.EntityFrameworkCore.Migrations;
using QueryOptimisation.Migrations.SeedData;

#nullable disable

namespace QueryOptimisation.Migrations
{
    public partial class AddChildren : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            foreach (var person in SeedData_Children.Children)
                migrationBuilder.InsertData(
                    table: "Person",
                    columns: new[] { "UniqueId", "Name", "Age", "JobTitle", "Salary", "DateCreated", "ParentId" },
                    values: new object[] { person.UniqueId, person.Name, person.Age, person.JobTitle, person.Salary, person.DateCreated, person.ParentId }
                );
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            foreach (var person in SeedData_Children.Children)
                migrationBuilder.DeleteData(
                    table: "Person",
                    keyColumn: "UniqueId",
                    keyValue: person.UniqueId
                );
        }
    }
}

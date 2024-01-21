using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QueryOptimisation.Models;

namespace QueryOptimisation.Config;

public class PersonConfig : IEntityTypeConfiguration<Person>
{
    public PersonConfig()
    {
    }

    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.HasKey(x => x.UniqueId);

        builder.HasMany(x => x.Children)
            .WithOne(x => x.Parent)
            .HasPrincipalKey(x => x.UniqueId)
            .HasForeignKey(x => x.ParentId);
    }
}
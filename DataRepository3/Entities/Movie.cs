using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataRepository3.Entities;

public class Movie : BaseEntity
{
    public string Name { get; set; } = null!;
    public bool IsWatched { get; set; }
    public string Author { get; set; } = null!;
}

public class MovieConfiguration : BaseEntityTypeConfiguration<Movie>
{
    public override void Configure(EntityTypeBuilder<Movie> builder)
    {
        base.Configure(builder);
        builder.Property(m => m.IsWatched).HasDefaultValue(false);
    }
}


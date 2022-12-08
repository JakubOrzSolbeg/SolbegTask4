using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataRepository3.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public int OrderNumber { get; set; }
}

public abstract class BaseEntityTypeConfiguration<TBase> : IEntityTypeConfiguration<TBase>
    where TBase : BaseEntity
{
    public virtual void Configure(EntityTypeBuilder<TBase> builder)
    {
        builder.Property(m => m.Id).ValueGeneratedOnAdd();
        builder.Property(m => m.OrderNumber).ValueGeneratedOnAdd();
        builder.HasKey(m => m.Id);
    }
}
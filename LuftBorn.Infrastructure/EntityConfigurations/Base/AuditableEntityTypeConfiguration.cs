using LuftBorn.Domain.Abstractions;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LuftBorn.Infrastructure.EntityConfigurations.Base
{
    public class AuditableEntityTypeConfiguration<T, TKey> : EntityTypeConfiguration<T, TKey>
       where T : AuditableEntity<TKey>
       where TKey : struct
    {
        public override void Configure(EntityTypeBuilder<T> builder)
        {
            base.Configure(builder);


            builder.Property(c => c.Created)
                .IsRequired();

            builder.Property(c => c.CreatedBy)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastModified)
                .IsRequired(false);

            builder.Property(c => c.LastModifiedBy)
                .HasMaxLength(50)
                .IsRequired(false);
        }
    }
}

using LuftBorn.Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuftBorn.Infrastructure.EntityConfigurations
{
    public class NotesConfiguration : IEntityTypeConfiguration<Note>
    {
        public void Configure(EntityTypeBuilder<Note> builder)
        {
            builder.HasKey(x => x.Id);
            builder.OwnsOne(s => s.Name, c =>
            {
                c.Property(n => n.DescriptionAr).HasColumnName("NameAr").IsRequired().HasMaxLength(50);
                c.Property(n => n.DescriptionEn).HasColumnName("NameEn").HasMaxLength(50);
            });

            builder.OwnsOne(s => s.Description, c =>
            {
                c.Property(n => n.DescriptionAr).HasColumnName("DescriptionAr");
                c.Property(n => n.DescriptionEn).HasColumnName("DescriptionEn");
            });


        }
    }
}

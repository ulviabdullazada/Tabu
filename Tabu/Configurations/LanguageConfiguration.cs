using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;
using Tabu.Entities;

namespace Tabu.Configurations
{
    public class LanguageConfiguration : IEntityTypeConfiguration<Language>
    {
        public void Configure(EntityTypeBuilder<Language> builder)
        {
            builder.HasKey(x => x.Code);
            builder.Property(x => x.Code)
                .IsRequired()
                .HasMaxLength(2);
            builder.HasIndex(x => x.Name)
                .IsUnique();
            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(64);
            builder.Property(x => x.Icon)
                .IsRequired()
                .HasMaxLength(128);
            builder.HasData(new Language
            {
                Code = "az",
                Icon = "https://cdn-icons-png.flaticon.com/512/330/330544.png",
                Name = "Azərbaycan"
            },
            new Language
            {
                Code = "en",
                Icon = "https://cdn3.iconfinder.com/data/icons/flag-world/512/flags-06-512.png",
                Name = "English"
            });
        }
    }
}

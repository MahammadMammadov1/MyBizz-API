using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybizz.Entities;

namespace Mybizz.Configurations
{
    public class ProfessionConfiguration : IEntityTypeConfiguration<Profession>
    {
        public void Configure(EntityTypeBuilder<Profession> builder)
        {
            builder.Property(x => x.Name)
                    .IsRequired()
                    .HasMaxLength(50);
        }
    }
}

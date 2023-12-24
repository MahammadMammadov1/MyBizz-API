using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Mybizz.Entities;

namespace Mybizz.Configurations
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.Property(x=>x.FullName)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.Desc)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.InstaUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.TwitUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.FaceUrl)
                    .IsRequired()
                    .HasMaxLength(50);
            builder.Property(x => x.ImagePath)
                    .IsRequired()
                    .HasMaxLength(100);

        }
    }
}

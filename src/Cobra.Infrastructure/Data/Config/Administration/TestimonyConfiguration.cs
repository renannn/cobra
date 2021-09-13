using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class TestimonyConfiguration : IEntityTypeConfiguration<Testimony>
    {
        public void Configure(EntityTypeBuilder<Testimony> builder)
        {
            builder.ToTable("tbl_user_testimonies", "dbo");

            builder.HasKey("Id")
                   .HasName("id_testimony");

            builder.HasOne(x => x.ReceiverUser)
                .WithMany(x => x.Testimonies)
                .HasForeignKey(x => x.ReceiverUserId)
                .HasConstraintName("cnst_testimonies_receiver_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SendedTestimonies)
                .HasForeignKey(x => x.SenderUserId)
                .HasConstraintName("cnst_testimonies_sender_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
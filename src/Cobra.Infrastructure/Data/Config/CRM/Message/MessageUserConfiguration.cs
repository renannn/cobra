using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class MessageUserConfiguration : IEntityTypeConfiguration<MensageUser>
    {
        public void Configure(EntityTypeBuilder<MensageUser> builder)
        {
            builder.ToTable("tbl_users_messages", "dbo");

            builder.HasKey("Id")
                   .HasName("id_message");

            builder.Property(t => t.Value)
                .HasColumnName("body")
                .IsRequired();

            builder.Property(t => t.CreatedDateTime)
                .HasColumnName("date_send")
                .IsRequired();

            builder.HasOne(x => x.ReceiverUser)
                .WithMany(x => x.ReceivedMensagesUser)
                .HasForeignKey(x => x.ReceiverUserId)
                .HasConstraintName("cnst_users_messages_receiver_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SendedMensagesUser)
                .HasForeignKey(x => x.SenderUserId)
                .HasConstraintName("cnst_users_messages_sender_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
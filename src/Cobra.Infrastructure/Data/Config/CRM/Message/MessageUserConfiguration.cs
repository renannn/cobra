using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class MessageUserConfiguration : IEntityTypeConfiguration<MensagemUser>
    {
        public void Configure(EntityTypeBuilder<MensagemUser> builder)
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

            builder.HasOne(x => x.TargetUser)
                   .WithMany(x => x.TargetMessages)
                   .HasForeignKey(x => x.TargetUserId)
                   .HasConstraintName("cnst_user_target_messages");

            builder.HasOne(x => x.SenderUser)
                   .WithMany(x => x.SenderMessages)
                   .HasForeignKey(x => x.TargetUserId)
                   .HasConstraintName("cnst_user_sender_messages");
        }
    }
}
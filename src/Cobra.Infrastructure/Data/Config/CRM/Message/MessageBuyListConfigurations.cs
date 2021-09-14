using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class MessageBuyListConfigurations : IEntityTypeConfiguration<MessageBuyList>
    {
        public void Configure(EntityTypeBuilder<MessageBuyList> builder)
        {
            builder.ToTable("tbl_users_buylists_messagens", "dbo");

            builder.HasKey("Id").HasName("id_buylists_messagens");

            builder.HasOne(x => x.ReceiverUser)
                .WithMany(x => x.ReceivedMessagesBuyList)
                .HasForeignKey(x => x.ReceiverUserId)
                .HasConstraintName("cnst_users_buylists_messagens_receiver_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SendedMessagesBuyList)
                .HasForeignKey(x => x.SenderUserId)
                .HasConstraintName("cnst_users_buylists_messagens_sender_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

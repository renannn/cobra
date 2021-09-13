using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class MessageBuyListItemConfigurations : IEntityTypeConfiguration<MessageBuyListItem>
    {
        public void Configure(EntityTypeBuilder<MessageBuyListItem> builder)
        {
            builder.ToTable("tbl_users_buylists_itens_messagens", "dbo");

            builder.HasOne(x => x.ReceiverUser)
                .WithMany(x => x.ReceivedMessagesBuyListItem)
                .HasForeignKey(x => x.ReceiverUserId)
                .HasConstraintName("cnst_messages_buylists_itens_receiver_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.SenderUser)
                .WithMany(x => x.SendedMessagesBuyListItem)
                .HasForeignKey(x => x.SenderUserId)
                .HasConstraintName("cnst_messages_buylists_itens_sender_user")
                .IsRequired(false)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

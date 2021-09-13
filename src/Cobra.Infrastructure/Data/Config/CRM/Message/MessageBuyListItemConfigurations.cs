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

        }
    }
}

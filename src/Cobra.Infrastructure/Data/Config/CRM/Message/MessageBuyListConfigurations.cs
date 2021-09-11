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
        }
    }
}

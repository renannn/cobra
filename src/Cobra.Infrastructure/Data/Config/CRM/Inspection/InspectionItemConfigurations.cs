using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class InspectionItemConfigurations : IEntityTypeConfiguration<InspectionItem>
    {
        public void Configure(EntityTypeBuilder<InspectionItem> builder)
        {
            builder.ToTable("tbl_users_buylists_inspections_itens", "dbo");

            builder.HasKey("Id").HasName("id_buylist_inspections_itens");
        }
    }
}
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cobra.Entities.Crm;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class InspectionItemConfigurations : IEntityTypeConfiguration<InspectionItem>
    {
        public void Configure(EntityTypeBuilder<InspectionItem> builder)
        {
            builder.ToTable("tbl_users_buylists_inspections_itens", "dbo");
        }
    }
}
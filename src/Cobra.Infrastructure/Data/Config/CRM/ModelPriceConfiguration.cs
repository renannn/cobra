using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ModelPriceConfiguration : IEntityTypeConfiguration<ModelPrice>
    {
        public void Configure(EntityTypeBuilder<ModelPrice> builder)
        {
            builder.ToTable("tbl_crm_models_prices", "dbo");
        }
    }
}
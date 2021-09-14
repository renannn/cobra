using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ModelPriceConfiguration : IEntityTypeConfiguration<ModelPrice>
    {
        public void Configure(EntityTypeBuilder<ModelPrice> builder)
        {
            builder.ToTable("tbl_models_prices", "dbo");

            builder.HasKey("Id").HasName("id__models_prices");

            builder.HasOne(x => x.Model)
                .WithMany(x => x.Prices)
                .HasForeignKey(x => x.ModelId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
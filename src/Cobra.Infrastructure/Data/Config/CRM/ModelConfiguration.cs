using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("tbl_crm_models", "dbo");

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Models)
                   .HasForeignKey(x => x.CategoryId);

            builder.HasOne(x => x.Brand)
                   .WithMany(x => x.Models)
                   .HasForeignKey(x => x.BrandId);
        }
    }
}
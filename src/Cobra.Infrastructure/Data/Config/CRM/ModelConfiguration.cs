using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class ModelConfiguration : IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder<Model> builder)
        {
            builder.ToTable("tbl_models", "dbo");

            builder.HasKey("Id").HasName("id_models");

            builder.HasOne(x => x.Category)
                   .WithMany(x => x.Models)
                   .HasForeignKey(x => x.CategoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Brand)
                   .WithMany(x => x.Models)
                   .HasForeignKey(x => x.BrandId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
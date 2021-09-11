using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Images
{
    public class ModelImageConfigurations : IEntityTypeConfiguration<ModelImage>
    {
        public void Configure(EntityTypeBuilder<ModelImage> builder)
        {
            builder.ToTable("tbl_images_models", "dbo");

            builder.HasOne(x => x.Model)
                   .WithMany(x => x.Images)
                   .HasForeignKey(x => x.ModelId);
        }
    }
}

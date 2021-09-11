using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class TestimonyConfiguration : IEntityTypeConfiguration<Testimony>
    {
        public void Configure(EntityTypeBuilder<Testimony> builder)
        {
            builder.ToTable("tbl_user_testimonies", "dbo");

            builder.HasKey("Id")
                   .HasName("id_testimony");
        }
    }
}
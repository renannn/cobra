using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Identity
{
    public class SubMenuConfiguration : IEntityTypeConfiguration<SubMenu>
    {
        public void Configure(EntityTypeBuilder<SubMenu> builder)
        {
            builder.ToTable("tbl_submenu", "dbo");

            builder.HasKey("Id")
                   .HasName("id_submenu");
        }
    }
}

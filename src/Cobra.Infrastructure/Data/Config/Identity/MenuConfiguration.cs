using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Identity
{
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("tbl_menu", "dbo");

            builder.HasKey("Id")
                   .HasName("id_menu");

            builder.HasMany(x => x.SubMenus)
                .WithOne(x => x.Menu)
                .HasForeignKey(x => x.MenuId);
        }
    }
}

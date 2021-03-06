using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class InspectionConfigurations : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.ToTable("tbl_users_buylists_inspections", "dbo");

            builder.HasKey("Id").HasName("id_buylist_inspections");

            builder.HasMany(x => x.InspectionItens)
                   .WithOne(x => x.Inspection)
                   .HasForeignKey(x => x.InspectionId)
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
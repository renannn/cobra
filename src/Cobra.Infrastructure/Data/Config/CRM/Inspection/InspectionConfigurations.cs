using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Cobra.Entities.Crm;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class InspectionConfigurations : IEntityTypeConfiguration<Inspection>
    {
        public void Configure(EntityTypeBuilder<Inspection> builder)
        {
            builder.ToTable("tbl_users_buylists_inspections", "dbo");

            builder.HasMany(x => x.InspectionItens)
                   .WithOne(x => x.Inspection)
                   .HasForeignKey(x => x.InspectionId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
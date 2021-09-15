using Cobra.Entities.Administration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Administration
{
    public class CompanySettingsConfiguration : IEntityTypeConfiguration<CompanySettings>
    {
        public void Configure(EntityTypeBuilder<CompanySettings> builder)
        {
            builder.ToTable("tbl_company_settings", "dbo");

            builder.HasNoKey();

        }
    }
}

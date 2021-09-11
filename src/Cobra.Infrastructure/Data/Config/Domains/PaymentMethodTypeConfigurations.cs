using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class PaymentMethodTypeConfigurations : IEntityTypeConfiguration<PaymentMethodType>
    {
        public void Configure(EntityTypeBuilder<PaymentMethodType> builder)
        {
            builder.ToTable("tbl_domains_payment_method_type", "dbo");

            builder.HasMany(x => x.PaymentMethods)
                   .WithOne(x => x.PaymentMethodType)
                   .HasForeignKey(x => x.PaymentMethodTypeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

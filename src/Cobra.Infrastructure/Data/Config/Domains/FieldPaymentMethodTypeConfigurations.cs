using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.Domains
{
    public class FieldPaymentMethodTypeConfigurations : IEntityTypeConfiguration<PaymentFieldMethodType>
    {
        public void Configure(EntityTypeBuilder<PaymentFieldMethodType> builder)
        {
            builder.ToTable("tbl_domains_field_payment_method_type", "dbo");

            builder.HasKey("Id").HasName("id_domains_field_payment_method_type");

            builder.HasOne(x => x.PaymentMethodType)
                .WithMany(x => x.PaymentFieldMethodTypes)
                .HasForeignKey(x => x.PaymentMethodTypeId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ctx_teste_domains_field_payment_method_type");
        }
    }
}

using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class PaymentValueFieldConfigurations : IEntityTypeConfiguration<PaymentValueField>
    {
        public void Configure(EntityTypeBuilder<PaymentValueField> builder)
        {
            builder.ToTable("tbl_users_payment_methods_values", "dbo");

            builder.HasKey("Id").HasName("id_users_payment_methods_values");

            builder.HasOne(x => x.PaymentMethod)
                .WithMany(x => x.PaymentValuesFields)
                .HasForeignKey(x => x.PaymentMethodId)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName("ctx_teste_renan");

            builder.HasOne(x => x.PaymentFieldMethodType)
                .WithMany(x => x.PaymentValuesFields)
                .HasForeignKey(x => x.PaymentFieldMethodTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
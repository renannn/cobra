using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class PaymentMethodConfigurations : IEntityTypeConfiguration<PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.ToTable("tbl_users_payment_methods", "dbo");

            builder.HasKey("Id").HasName("id_users_payment_methods");

            builder.HasOne(x => x.Bank)
                .WithMany(x => x.PaymentMethods)
                .HasForeignKey(x => x.PaymentMethodTypeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
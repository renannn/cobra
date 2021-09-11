using Cobra.Entities.Crm;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cobra.Infrastructure.Data.Config.CRM
{
    public class PaymentValueFieldConfigurations : IEntityTypeConfiguration<PaymentValueField>
    {
        public void Configure(EntityTypeBuilder<PaymentValueField> builder)
        {
            builder.ToTable("tbl_users_payment_methods_values", "dbo");
        }
    }
}
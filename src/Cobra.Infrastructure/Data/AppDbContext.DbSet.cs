using Cobra.Entities.Administration;
using Cobra.Entities.Crm;
using Cobra.Entities.Domains;
using Microsoft.EntityFrameworkCore;

namespace Cobra.Infrastructure.Data
{
    public partial class AppDbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Email> Emails { get; set; }
        public DbSet<Phone> Phones { get; set; }
        public DbSet<UsedPassword> UsedPasswords { get; set; }
        public DbSet<BuyList> BuyLists { get; set; }
        public DbSet<BuyListItem> BuyListItens { get; set; }
        public DbSet<Inspection> Inspections { get; set; }
        public DbSet<InspectionItem> InspectionItems { get; set; }
        public DbSet<MensagemUser> MensagensUsers { get; set; }
        public DbSet<MessageBuyList> MessagesBuyLists { get; set; }
        public DbSet<MessageBuyListItem> MessagesBuyListItems { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentValueField> ValuesPaymentFields { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<ModelPrice> ModelPrices { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Condition> Conditions { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmailType> EmailTypes { get; set; }
        public DbSet<PaymentFieldMethodType> FieldPaymentMethodTypes { get; set; }
        public DbSet<PaymentMethodType> PaymentMethodTypes { get; set; }
        public DbSet<PhoneType> PhoneTypes { get; set; }
        public DbSet<RegionalState> RegionalStates { get; set; }
        public DbSet<BrandImage> BrandImages { get; set; }
        public DbSet<BuyListItemImage> BuyListItemImages { get; set; }
        public DbSet<InspectionItemImage> InspectionItemImages { get; set; }
        public DbSet<ModelImage> ModelImages { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Menu> Menu { get; set; }
        public DbSet<SubMenu> SubMenu { get; set; }
    }
}

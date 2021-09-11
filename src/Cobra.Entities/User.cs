using Cobra.Entities.Crm;
using Cobra.SharedKernel.Enums;
using Cobra.SharedKernel.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;

namespace Cobra.Entities.Administration
{
    public class User : IdentityUser<Guid>,
        IAggregateRoot,
        IAuditableEntity,
        IBaseEntity,
        IHasId<Guid>,
        IHasCreationDate,
        IHasDisabled,
        IHasName,
        IHasSurname
    {
        #region Constructors

        public User() : base() { }

        public User(string username, string name, string surname) : base(username)
        {
            Name = name;
            Surname = surname;
        }

        #endregion

        public PersonType PersonType { get; set; }
        public string MainDocument { get; set; }
        public string RG { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhotoFileName { get; set; }
        public DateTime? BirthDate { get; set; }
        public bool IsDisabled { get; set; }
        public BlockedState BlockedState { get; set; }
        public DateTime? LastVisitDateTime { get; set; }

        #region IHasPhone
        public virtual List<Phone> Phones { get; set; } = new();
        #endregion

        #region IHasEmail
        public virtual List<Email> Emails { get; set; } = new();
        #endregion

        #region IHasBuyList
        public virtual List<BuyList> BuyLists { get; set; } = new();
        #endregion

        #region IHasPaymentMethod
        public virtual List<PaymentMethod> PaymentMethods { get; set; } = new();
        #endregion

        #region IHasChange
        public virtual List<AppLogItem> Changes { get; set; } = new();
        #endregion

        #region IHasRoles
        public virtual List<UserRole> Roles { get; set; } = new();
        #endregion

        #region IHasLogins
        public virtual List<UserLogin> Logins { get; set; } = new();
        #endregion

        #region IHasClaims
        public virtual List<UserClaim> Claims { get; set; } = new();
        #endregion

        #region IHasUserUsedPasswords
        public virtual List<UsedPassword> UserUsedPasswords { get; set; } = new();
        #endregion

        #region IHasTokens
        public virtual List<UserToken> Tokens { get; set; } = new();
        #endregion

        #region IHasAddress
        public virtual List<Address> Addresses { get; set; } = new();
        #endregion

        #region IHasTestimonies
        public virtual List<Testimony> Testimonies { get; set; } = new();
        #endregion
        
        public virtual List<MensagemUser> TargetMessages { get; set; } = new();
        public virtual List<MensagemUser> SenderMessages { get; set; } = new();
        public virtual List<Payment> Payments { get; set; } = new();

        public DateTime? CreatedDateTime { get; set; }
        public string DisplayName()
        {
            var displayName = $"{Name} {Surname}";
            return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
        }
    }
}

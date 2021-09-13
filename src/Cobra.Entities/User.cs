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
        IHasSurname,
        IHasPhones<Phone>,
        IHasEmails<Email>,
        IHasBuyLists<BuyList>,
        IHasTokens<UserToken>
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
        public bool IsEmailPublic { get; set; }
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

        #region IHasChange<AppLogItem>
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

        public virtual List<Payment> Payments { get; set; } = new();

        #region Testimony

        public virtual List<Testimony> Testimonies { get; set; } = new();
        public virtual List<Testimony> SendedTestimonies { get; set; } = new();

        #endregion

        #region MessageBuyList

        public virtual List<MessageBuyList> ReceivedMessagesBuyList { get; set; } = new();
        public virtual List<MessageBuyList> SendedMessagesBuyList { get; set; } = new();

        #endregion

        #region MessageBuyListItem

        public virtual List<MessageBuyListItem> ReceivedMessagesBuyListItem { get; set; } = new();
        public virtual List<MessageBuyListItem> SendedMessagesBuyListItem { get; set; } = new();

        #endregion

        #region MensageUser

        public virtual List<MensageUser> ReceivedMensagesUser { get; set; } = new();
        public virtual List<MensageUser> SendedMensagesUser { get; set; } = new();

        #endregion

        public DateTime? CreatedDateTime { get; set; }

        public string DisplayName()
        {
            var displayName = $"{Name} {Surname}";
            return string.IsNullOrWhiteSpace(displayName) ? UserName : displayName;
        }
    }
}

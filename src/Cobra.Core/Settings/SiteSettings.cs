using Cobra.Common.Mail;
using Microsoft.AspNetCore.Identity;
using System;

namespace Cobra.Core.Settings
{
    public class SiteSettings
    {
        public Security Security { get; set; }
        public AdminUserSeed AdminUserSeed { get; set; }
        public Logging Logging { get; set; }
        public SmtpConfig Smtp { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
        public bool EnableEmailConfirmation { get; set; }
        public TimeSpan EmailConfirmationTokenProviderLifespan { get; set; }
        public int NotAllowedPreviouslyUsedPasswords { get; set; }
        public int ChangePasswordReminderDays { get; set; }
        public PasswordOptions PasswordOptions { get; set; }
        public ActiveDatabase ActiveDatabase { get; set; }
        public string UsersAvatarsFolder { get; set; }
        public string UserDefaultPhoto { get; set; }
        public string ContentSecurityPolicyErrorLogUri { get; set; }
        public CookieOptions CookieOptions { get; set; }
        public DataProtectionOptions DataProtectionOptions { get; set; }
        public LockoutOptions LockoutOptions { get; set; }
        public UserAvatarImageOptions UserAvatarImageOptions { get; set; }
        public string[] EmailsBanList { get; set; }
        public string[] PasswordsBanList { get; set; }
        public DataProtectionX509Certificate DataProtectionX509Certificate { get; set; }
        public Uri RemoteDependency { get; set; }
        public string DiretorioArquivo { get; set; }
        public string SiteUrl { get; set; }
        public string ApiUri { get; set; }
    }
}
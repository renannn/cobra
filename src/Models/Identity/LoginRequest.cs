﻿namespace Cobra.Models.Identity
{
    public class LoginRequest
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public string GrantType { get; set; }
    }
}
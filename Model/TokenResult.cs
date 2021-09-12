using System.Collections.Generic;

namespace Cobra.Models.Identity
{
    public class TokenResult
    {
        public bool Authenticated { get; set; }
        public string Created { get; set; }
        public string Expiration { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
        public string Message { get; set; }
        public string Nome { get; set; }
        public string Username { get; set; }
        public List<string> Roles { get; set; }
    }
}

using Cobra.Entities.Administration;
using Cobra.SharedKernel;

namespace Cobra.Models.Identity
{
    public class AgeStatViewModel
    {
        public const char RleChar = (char)0x202B;

        public int UsersCount { set; get; }
        public int AverageAge { set; get; }
        public User MaxAgeUser { set; get; }
        public User MinAgeUser { set; get; }
        public string MinMax => $"{RleChar}Membro mais jovem: {MinAgeUser.DisplayName()} ({MinAgeUser.BirthDate.Value.GetAge()}), Membro mais antigo: {MaxAgeUser.DisplayName()} ({MaxAgeUser.BirthDate.Value.GetAge()}), entre as pessoas {UsersCount}";
    }
}
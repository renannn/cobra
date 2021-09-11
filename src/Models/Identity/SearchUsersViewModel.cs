using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class SearchUsersViewModel
    {
        [Display(Name = "Texto a encontrar")]
        public string TextToFind { set; get; }

        [Display(Name = "É parte do email")]
        public bool IsPartOfEmail { set; get; }

        [Display(Name = "Número do usuário")]
        public bool IsUserId { set; get; }

        [Display(Name = "É parte do nome")]
        public bool IsPartOfName { set; get; }

        [Display(Name = "É parte do sobrenome")]
        public bool IsPartOfLastName { set; get; }

        [Display(Name = "É parte do nome de usuário")]
        public bool IsPartOfUserName { set; get; }

        [Display(Name = "É parte da localização")]
        public bool IsPartOfLocation { set; get; }

        [Display(Name = "O email foi confirmado")]
        public bool HasEmailConfirmed { set; get; }

        [Display(Name = "Apenas ativado")]
        public bool UserIsActive { set; get; }

        [Display(Name = "Exibir todos os usuários")]
        public bool ShowAllUsers { set; get; }

        [Display(Name = "Tem uma conta bloqueada")]
        public bool UserIsLockedOut { set; get; }

        [Display(Name = "É possui validação em 2 fatores")]
        public bool HasTwoFactorEnabled { set; get; }

        [Display(Name = "Número de linhas de retorno")]
        [Required(ErrorMessage = "(*)")]
        [Range(1, 1000, ErrorMessage = "O número inserido deve ser especificado no intervalo de 1 a 1000")]
        public int MaxNumberOfRows { set; get; }

        public PagedUsersListViewModel PagedUsersList { set; get; }

        public SearchUsersViewModel()
        {
            ShowAllUsers = true;
            MaxNumberOfRows = 7;
        }
    }
}
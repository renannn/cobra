using Cobra.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cobra.Models.Identity
{
    public class UserProfileViewModel
    {
        public const string AllowedImages = ".png,.jpg,.jpeg,.gif";

        [Required(ErrorMessage = "(*)")]
        [Display(Name = "Nome do usuário")]
        [Remote("ValidateUsername", "UserProfile",
            AdditionalFields = nameof(Email) + "," + ViewModelConstants.AntiForgeryToken + "," + nameof(Pid),
            HttpMethod = "POST")]
        public string UserName { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        public string FirstName { get; set; }

        [Display(Name = "Sobrenome")]
        [Required(ErrorMessage = "(*)")]
        [StringLength(450)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "(*)")]
        [Remote("ValidateUsername", "UserProfile",
            AdditionalFields = nameof(UserName) + "," + ViewModelConstants.AntiForgeryToken + "," + nameof(Pid),
            HttpMethod = "POST")]
        [EmailAddress(ErrorMessage = "Por favor insira um endereço de e-mail válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Imagem")]
        [StringLength(maximumLength: 1000, ErrorMessage = "O comprimento máximo do endereço da imagem é de 1000 caracteres.")]
        public string PhotoFileName { set; get; }

        [UploadFileExtensions(AllowedImages,
            ErrorMessage = "Por favor, apenas uma imagem do formato " + AllowedImages + "pode ser enviada.")]
        [DataType(DataType.Upload)]
        public IFormFile Photo { get; set; }

        public int? DateOfBirthYear { set; get; }
        public int? DateOfBirthMonth { set; get; }
        public int? DateOfBirthDay { set; get; }

        [Display(Name = "Residência")]
        public string Location { set; get; }

        [Display(Name = "O email é público")]
        public bool IsEmailPublic { set; get; }

        [Display(Name = "Ativar validação de 2 fatores")]
        public bool TwoFactorEnabled { set; get; }

        public bool IsPasswordTooOld { set; get; }

        [HiddenInput]
        public string Pid { set; get; }

        [HiddenInput]
        public bool IsAdminEdit { set; get; }
    }
}
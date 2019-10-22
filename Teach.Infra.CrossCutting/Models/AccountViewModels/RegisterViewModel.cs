using System;
using System.ComponentModel.DataAnnotations;

namespace Teach.Infra.CrossCutting.Identity.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Nome é um campo obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, ErrorMessage = "O {0} deve ter pelo menos {2} e no máximo {1} caracteres.", MinimumLength = 3)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email é um campo obrigatório")]
        [RegularExpression(@"^(([A-Za-z0-9]+_+)|([A-Za-z0-9]+\-+)|([A-Za-z0-9]+\.+)|([A-Za-z0-9]+\++))*[A-Za-z0-9]+@((\w+\-+)|(\w+\.))*\w{1,63}\.[a-zA-Z]{2,6}$", ErrorMessage = "Email está em um formato inválido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Senha é um campo obrigatório", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Telefone é um campo obrigatório", AllowEmptyStrings = false)]
        [RegularExpression(@"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$", ErrorMessage = "Celular está em um formato inválido.")]
        [Display(Name = "Celular")]
        public string CellPhone { get; set; }
    }
}

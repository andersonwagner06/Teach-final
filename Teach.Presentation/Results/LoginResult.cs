using Teach_API.Models;

namespace Teach_API.Results
{
    public class LoginResult : ResultBase
    {
        public long IdUsuario { get; set; }

        public override bool ValidarModel(object model)
        {
            base.ValidarModel(model);

            var loginModel = (LoginModel)model;
            if (string.IsNullOrEmpty(loginModel.Login) || string.IsNullOrEmpty(loginModel.Senha))
            {
                Mensagem.Add("Parâmetros incorretos, é necessário informar o Login e Senha do usuário");
                return false;
            }

            return true;
        }
    }
}

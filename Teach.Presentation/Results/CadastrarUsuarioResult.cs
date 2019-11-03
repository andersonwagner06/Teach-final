using Teach_API.Models;

namespace Teach_API.Results
{
    public class CadastrarUsuarioResult : ResultBase
    {
        public long IdUsuario { get; set; }

        public override bool ValidarModel(object model)
        {
            base.ValidarModel(model);

            var usuarioModel = (UsuarioModel)model;
            if (usuarioModel == null || usuarioModel == new UsuarioModel())
            {
                Mensagem.Add("É necessário enviar os parâmetros para cadastrar o usuário.");
                return false;
            }

            return true;
        }
    }
}

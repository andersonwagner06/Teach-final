using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class AlterarDadosUsuarioResult : ResultBase
    {
        public override bool ValidarModel(object model)
        {
            base.ValidarModel(model);

            var usuarioModel = (UsuarioModel)model;
            if (usuarioModel == null || usuarioModel == new UsuarioModel() || usuarioModel.IdUsuario <= 0)
            {
                Mensagem.Add("É necessário enviar os parâmetros para cadastrar o usuário.");
                return false;
            }

            return true;
        }
    }
}

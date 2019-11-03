using Microsoft.AspNetCore.Mvc;
using Teach_API.Models;
using Teach_API.Repositories;
using Teach_API.Repositories.Interfaces;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //private readonly IUsuarioRepository _usuarioRepository;
        ////TODO: ADICIONAR INJEÇÃO DE DEPENDENCIA
        //public UsuarioController(IUsuarioRepository usuarioRepository)
        //{
        //    _usuarioRepository = usuarioRepository;
        //}
        //[RequireHttps]
        [HttpGet]
        [Route("fazerlogin")]
        public LoginResult FazerLogin([FromBody]LoginModel loginModel)
        {
            var result = new LoginResult();

            if (!result.ValidarModel(loginModel))
                return result;

            var repository = new UsuarioRepository();

            result.IdUsuario = repository.ValidarLogin(loginModel);

            if (result.IdUsuario == 0)
                result.Mensagem.Add("Não foi possível localizar o usuário informado. Verifique as credenciais de acesso");

            return result;
        }

        [HttpPost]
        [Route("cadastrar")]
        public CadastrarUsuarioResult CadastrarUsuario([FromBody]UsuarioModel dadosUsuario)
        {
            var result = new CadastrarUsuarioResult();

            if (!result.ValidarModel(dadosUsuario))
                return result;

            var repository = new UsuarioRepository();
         
            if(repository.ValidarContaExistente(dadosUsuario.Email))
            {
                result.Mensagem.Add("Já existe um usuário cadastrado para o e-mail informado.");
                return result;
            }

            result.IdUsuario = repository.CadastrarUsuario(dadosUsuario);

            if(result.IdUsuario == 0)
            {
                result.Mensagem.Add("Não foi possível cadastrar o usuário informado, houve um erro ao realizar a operação.");
                return result;
            }

            return result;
        }

        [HttpGet]
        [Route("obterDados")]
        public UsuarioResult ObterDadosUsuario([FromHeader]int idUsuario)
        {
            var result = new UsuarioResult();

            if (idUsuario <= 0)
            {
                result.Mensagem.Add("O id informado é inválido.");
                return result;
            }

            var repository = new UsuarioRepository();

           result.Usuario = repository.ObterDadosUsuario(idUsuario);

            if (result.Usuario == new Usuario())
                result.Mensagem.Add(string.Format("Não foi possível localizar o usuário informado. Id {0}", idUsuario));

            return result;
        }

        [HttpGet]
        [Route("alterar")]
        public AlterarDadosUsuarioResult AlterarUsuario([FromBody]UsuarioModel usuario)
        {
            var result = new AlterarDadosUsuarioResult();

            if(!result.ValidarModel(usuario))
                return result;

            var repository = new UsuarioRepository();

            var sucesso = repository.AtualizarDadosUsuario(usuario);

            if(!sucesso)
            result.Mensagem.Add("Não foi possível atualizar os dados do usuário. Houve um ou mais erros ao realizar a operação.");

            return result;
        }
    }
}

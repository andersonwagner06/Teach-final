using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Teach_API.Repositories;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/areaestudo")]
    [ApiController]
    public class AreaEstudoController : ControllerBase
    {
        [HttpGet]
        [Route("obterareasgerais")]
        public AreaEstudoResult ObterAreasGerais()
        {
            var result = new AreaEstudoResult();

            var repository = new AreaEstudoRepository();

            result.AreasEstudo = repository.ObterAreaEstudoGeral();

            if (!result.AreasEstudo.Any())
                result.Mensagem.Add("Houve um erro realizar a busca das áreas de estudo.");

            return result;
        }

        [HttpGet]
        [Route("obterareasespecificas")]
        public AreaEstudoResult ObterAreasEspecificas([FromHeader]int idAreaGeral)
        {
            var result = new AreaEstudoResult();

            if(idAreaGeral == 0)
               result.Mensagem.Add("Id não informado.");

            var repository = new AreaEstudoRepository();

            result.AreasEstudo = repository.ObterAreaEstudoEspecifica(idAreaGeral);

            if (!result.AreasEstudo.Any())
                result.Mensagem.Add("Houve um erro realizar a busca das áreas de estudo. Certifique-se que o ID da área geral é válido.");

            return result;
        }
    }
}

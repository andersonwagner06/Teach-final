using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Teach_API.Repositories;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/universidade")]
    [ApiController]
    public class UniversidadeController : ControllerBase
    {
        [HttpGet]
        [Route("obteruniversidades")]
        public UniversidadeResult ObterUniversidades()
        {
            var result = new UniversidadeResult();

            var repository = new UniversidadeRepository();

            result.Universidades = repository.ObterUniversidades();

            if (!result.Universidades.Any())
                result.Mensagem.Add("Houve um erro realizar a busca das universidades.");

            return result;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Repositories;
using Teach_API.Results;

namespace Teach_API.Controllers
{
    [Route("api/idioma")]
    [ApiController]
    public class IdiomaController : ControllerBase
    {
        [HttpGet]
        [Route("obter")]
        public IdiomasResult ObterIdiomas()
        {
            var result = new IdiomasResult();

            var repository = new IdiomaRepository();

            result.Idiomas = repository.ObterIdiomas();

            if (!result.Idiomas.Any())
                result.Mensagem.Add("Houve um erro realizar a busca dos idiomas.");

            return result;
        }
    }
}

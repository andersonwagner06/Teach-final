using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;
using Teach_API.Results;

namespace Teach_API.Repositories.Interfaces
{
    public interface IAreaEstudoRepository
    {
        IList<AreaEstudo> ObterAreaEstudoGeral();
        IList<AreaEstudo> ObterAreaEstudoEspecifica(int idAreaEstudoGeral);
    }
}

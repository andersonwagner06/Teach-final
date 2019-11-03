using System.Collections.Generic;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class UniversidadeResult : ResultBase
    {
        public IList<Universidade> Universidades { get; set; }

        public UniversidadeResult()
        {
            Universidades = new List<Universidade>();
        }
    }
}

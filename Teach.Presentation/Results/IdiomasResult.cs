using System.Collections.Generic;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class IdiomasResult : ResultBase
    {
        public IList<Idioma> Idiomas { get; set; }

        public IdiomasResult()
        {
            Idiomas = new List<Idioma>();
        }
    }
}

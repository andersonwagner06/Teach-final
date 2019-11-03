using System.Collections.Generic;
using Teach_API.Models;

namespace Teach_API.Results
{
    public class AreaEstudoResult : ResultBase
    {
        public IList<AreaEstudo> AreasEstudo { get; set; }

        public AreaEstudoResult()
        {
            AreasEstudo = new List<AreaEstudo>();
        }
    }
}

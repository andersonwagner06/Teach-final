using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Teach_API.Results
{
    public class ResultBase
    {
        public bool Sucesso { get { return Mensagem == null || !Mensagem.Any(); } }
        public List<string> Mensagem { get; set; }

        public ResultBase()
        {
            Mensagem = new List<string>();
        }

        public virtual bool ValidarModel(object model)
        {
            if(model == null)
            {
                Mensagem.Add("É necessário passar o JSON de parâmetro");
                return false;
            }

            return true;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Enums;

namespace Teach_API.Models
{
    public class Usuario
    {
        public long Id { get; set; }
        public string CaminhoFoto { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public Idioma IdiomaOrigem { get; set; }
        public Idioma IdiomaParaAprender { get; set; }
        public Idioma IdiomaFluenteSecundario { get; set; }
        public Universidade Universidade { get; set; }
        public AreaEstudo AreaEstudoDominioGeral { get; set; }
        public AreaEstudo AreaEstudoDominioEspecifica { get; set; }
        public AreaEstudo AreaEstudoParaAprenderGeral { get; set; }
        public AreaEstudo AreaEstudoParaAprenderEspecifico { get; set; }
        public TipoIteracao TipoIteracao { get; set; }
    }
}

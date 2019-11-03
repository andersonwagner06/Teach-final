using System;
using Teach_API.Enums;

namespace Teach_API.Models
{
    public class UsuarioModel
    {
        public int? IdUsuario { get; set; }
        public string CaminhoFoto { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public Genero Genero { get; set; }
        public DateTime DataNascimento { get; set; }
        public long IdIdiomaOrigem { get; set; }
        public long? IdIdiomaAprendizado { get; set; }
        public long? IdIdiomaDominio { get; set; }
        public long Universidade { get; set; }
        public long IdAreaEstudoGeralDominio { get; set; }
        public long IdAreaEstudoGeralAprendizado { get; set; }
        public long IdAreaEstudoEspecificoDominio { get; set; }
        public long IdAreaEstudoEspecificoAprendizado { get; set; }
        public TipoIteracao TipoIteracao { get; set; }
    }
}

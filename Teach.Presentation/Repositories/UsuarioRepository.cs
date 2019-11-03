using System;
using System.Data.SqlClient;
using Teach_API.Enums;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;
using Teach_API.Results;

namespace Teach_API.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private SqlConnection _connection;

        public UsuarioRepository()
        {
            ValidarConnection();
        }

        public int CadastrarUsuario(UsuarioModel usuario)
        {
            try
            {
                var sql = @"INSERT INTO usuario (
                                            email, 
                                            nome_usuario, 
                                            senha, 
                                            data_nascimento, 
                                            genero, 
                                            caminho_foto, 
                                            idioma_materno, 
                                            idioma_para_praticar, 
                                            idioma_fluente, 
                                            universidade, 
                                            area_estudo_geral_dominio, 
                                            area_estudo_especifico_dominio,
                                            area_estudo_geral_aprendizado, 
                                            area_estudo_especifico_aprendizado, 
                                            preferencia_conversa)
                                    VALUES (
                                            @email, 
                                            @nomeusuario, 
                                            @senha, 
                                            @datanascimento, 
                                            @genero, 
                                            @caminhofoto, 
                                            @idiomaMaterno, 
                                            @idiomaPraticar, 
                                            @idiomaFluente, 
                                            @universidade, 
                                            @areaestudogeraldominio, 
                                            @areaestudoespecificodominio, 
                                            @areaestudogeralaprendizado, 
                                            @areaestudoespecificoaprendizado, 
                                            @preferenciaconversa
                                            )

           SELECT IDENT_CURRENT('usuario') AS id_usuario";

                ValidarConnection();

                using (SqlConnection connection = _connection)
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", usuario.Email);
                        command.Parameters.AddWithValue("@nomeusuario", usuario.Nome);
                        command.Parameters.AddWithValue("@senha", usuario.Senha);
                        command.Parameters.AddWithValue("@datanascimento", usuario.DataNascimento);
                        command.Parameters.AddWithValue("@genero", (int)usuario.Genero);
                        command.Parameters.AddWithValue("@caminhofoto", usuario.CaminhoFoto);
                        command.Parameters.AddWithValue("@idiomaMaterno", usuario.IdIdiomaOrigem);
                        command.Parameters.AddWithValue("@idiomaPraticar", usuario.IdIdiomaAprendizado);
                        command.Parameters.AddWithValue("@idiomaFluente", usuario.IdIdiomaDominio);
                        command.Parameters.AddWithValue("@universidade", usuario.Universidade);
                        command.Parameters.AddWithValue("@areaestudogeraldominio", usuario.IdAreaEstudoGeralDominio);
                        command.Parameters.AddWithValue("@areaestudoespecificodominio", usuario.IdAreaEstudoEspecificoDominio);
                        command.Parameters.AddWithValue("@areaestudogeralaprendizado", usuario.IdAreaEstudoGeralAprendizado);
                        command.Parameters.AddWithValue("@areaestudoespecificoaprendizado", usuario.IdAreaEstudoEspecificoAprendizado);
                        command.Parameters.AddWithValue("@preferenciaconversa", (int)usuario.TipoIteracao);

                        using (var reader = command.ExecuteReader())
                        {
                            return reader.Read() ? Convert.ToInt32(reader["id_usuario"]) : 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
        public int ValidarLogin(LoginModel loginModel)
        {
            var sql = @"SELECT id_usuario
                        FROM usuario
                        WHERE email = @email
                        AND senha = @senha";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", loginModel.Login);
                    command.Parameters.AddWithValue("@senha", loginModel.Senha);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? Convert.ToInt32(reader["id_usuario"]) : 0;
                    }
                }
            }
        }

        public bool ValidarContaExistente(string email)
        {
            var sql = @"SELECT id_usuario
                        FROM usuario
                        WHERE email = @email";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@email", email);

                    using (var reader = command.ExecuteReader())
                    {
                        return reader.Read() ? true : false;
                    }
                }
            }
        }

        public Usuario ObterDadosUsuario(int idUsuario)
        {
            var sql = @"SELECT u.id_usuario AS idUsuario
	                            ,u.caminho_foto AS caminhoFoto
	                            ,u.nome_usuario AS nomeUsuario
	                            ,u.email AS email
	                            ,u.senha AS senha
	                            ,u.genero AS genero
	                            ,u.data_nascimento AS dataNascimento
	                            ,u.preferencia_conversa AS preferenciaConversa
	                            ,un.id_universidade AS idUniversidade
	                            ,un.universidade AS universidade
	                            ,aed.id_area_estudo_especifico AS idEspecificaDominio
	                            ,aed.area_especifica_descricao AS descEspecificaDominio
	                            ,aea.id_area_estudo_especifico AS idEspecificaAprendizado
	                            ,aea.area_especifica_descricao AS descEspecificaAprendizado
	                            ,agd.id_area_geral AS idGeralDominio
	                            ,agd.area_geral_descricao AS descGeralDominio
	                            ,aga.id_area_geral AS idGeralAprendizado
	                            ,aga.area_geral_descricao AS descGeralAprendizado
	                            ,imat.id_idioma AS idIdiomaMaterno
	                            ,imat.idioma AS descIdiomaMaterno
	                            ,iflu.id_idioma AS idIdiomaFluente
	                            ,iflu.idioma AS descIdiomaFluente
	                            ,iprat.id_idioma AS idIdiomaAprender
	                            ,iprat.idioma AS descIdiomaAprender
                            FROM usuario u
                            INNER JOIN universidades un ON (u.universidade = un.id_universidade)
                            INNER JOIN area_estudo_especifico aed ON (aed.id_area_estudo_especifico = u.area_estudo_especifico_dominio)
                            INNER JOIN area_estudo_especifico aea ON (aea.id_area_estudo_especifico = u.area_estudo_especifico_aprendizado)
                            INNER JOIN area_estudo_geral agd ON (agd.id_area_geral = u.area_estudo_geral_dominio)
                            INNER JOIN area_estudo_geral aga ON (aga.id_area_geral = u.area_estudo_geral_aprendizado)
                            INNER JOIN idiomas imat ON (imat.id_idioma = u.idioma_materno)
                            INNER JOIN idiomas iflu ON (iflu.id_idioma = ISNULL(u.idioma_fluente, u.idioma_materno))
                            INNER JOIN idiomas iprat ON (iprat.id_idioma = u.idioma_para_praticar)
                            WHERE u.id_usuario = @idUsuario";

            ValidarConnection();

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Usuario()
                            {
                                Id = Convert.ToInt32(reader["idUsuario"]),
                                CaminhoFoto = reader["caminhoFoto"].ToString(),
                                Nome = reader["nomeUsuario"].ToString(),
                                Email = reader["email"].ToString(),
                                Senha = reader["senha"].ToString(),
                                Genero = (Genero)Convert.ToInt32(reader["genero"]),
                                DataNascimento = Convert.ToDateTime(reader["dataNascimento"]),
                                IdiomaOrigem = new Idioma { Id = Convert.ToInt32(reader["idIdiomaMaterno"]), Descricao = reader["descIdiomaMaterno"].ToString() },
                                IdiomaParaAprender = new Idioma { Id = Convert.ToInt32(reader["idIdiomaAprender"]), Descricao = reader["descIdiomaAprender"].ToString() },
                                IdiomaFluenteSecundario = new Idioma { Id = Convert.ToInt32(reader["idIdiomaFluente"]), Descricao = reader["descIdiomaFluente"].ToString()},
                                Universidade = new Universidade { Id = Convert.ToInt32(reader["idUniversidade"]), Descricao = reader["universidade"].ToString() },
                                AreaEstudoDominioGeral = new AreaEstudo { Id = Convert.ToInt32(reader["idGeralDominio"]), Descricao = reader["descGeralDominio"].ToString()},
                                AreaEstudoDominioEspecifica = new AreaEstudo { Id = Convert.ToInt32(reader["idEspecificaDominio"]), Descricao = reader["descEspecificaDominio"].ToString()},
                                AreaEstudoParaAprenderGeral = new AreaEstudo { Id = Convert.ToInt32(reader["idGeralAprendizado"]), Descricao = reader["descGeralAprendizado"].ToString() },
                                AreaEstudoParaAprenderEspecifico = new AreaEstudo { Id = Convert.ToInt32(reader["idEspecificaAprendizado"]), Descricao = reader["descEspecificaAprendizado"].ToString() },
                                TipoIteracao = (TipoIteracao)Convert.ToInt32(reader["preferenciaConversa"])
                            };
                        }
                    }
                }
            }
            return new Usuario();
        }

        public bool AtualizarDadosUsuario(UsuarioModel usuario)
        {
            try
            {  
                var sql = @"UPDATE usuario
                            SET email = @email
	                            ,nome_usuario = @nomeUsuario
	                            ,senha = @senha
	                            ,data_nascimento = @dataNascimento
	                            ,genero = @genero
	                            ,caminho_foto = @caminhofoto
	                            ,idioma_materno = @idiomaMaterno
	                            ,idioma_para_praticar = @idiomaPraticar
	                            ,idioma_fluente = @idiomaFluente
	                            ,universidade = @universidade
	                            ,area_estudo_especifico_aprendizado = @areaEspecificaAprendizado
	                            ,area_estudo_especifico_dominio = @areaEspecificaDominio
	                            ,area_estudo_geral_aprendizado = @areaGeralAprendizado
	                            ,area_estudo_geral_dominio = @areaGeralDominio
	                            ,preferencia_conversa = @preferenciaConversa
                            WHERE id_usuario = @idUsuario";

                ValidarConnection();

                using (SqlConnection connection = _connection)
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@email", usuario.Email);
                        command.Parameters.AddWithValue("@nomeUsuario", usuario.Nome);
                        command.Parameters.AddWithValue("@senha", usuario.Senha);
                        command.Parameters.AddWithValue("@dataNascimento", usuario.DataNascimento);
                        command.Parameters.AddWithValue("@genero", (int)usuario.Genero);
                        command.Parameters.AddWithValue("@caminhofoto", usuario.CaminhoFoto );
                        command.Parameters.AddWithValue("@idiomaMaterno", usuario.IdIdiomaOrigem);
                        command.Parameters.AddWithValue("@idiomaPraticar", usuario.IdIdiomaAprendizado);
                        command.Parameters.AddWithValue("@idiomaFluente", usuario.IdIdiomaAprendizado);
                        command.Parameters.AddWithValue("@universidade", usuario.Universidade);
                        command.Parameters.AddWithValue("@areaEspecificaAprendizado", usuario.IdAreaEstudoEspecificoAprendizado);
                        command.Parameters.AddWithValue("@areaEspecificaDominio", usuario.IdAreaEstudoEspecificoDominio);
                        command.Parameters.AddWithValue("@areaGeralAprendizado", usuario.IdAreaEstudoGeralAprendizado);
                        command.Parameters.AddWithValue("@areaGeralDominio", usuario.IdAreaEstudoGeralDominio);
                        command.Parameters.AddWithValue("@preferenciaConversa", (int)usuario.TipoIteracao);
                        command.Parameters.AddWithValue("@idUsuario", usuario.IdUsuario);

                        command.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ValidarConnection()
        {
            if (_connection == null || string.IsNullOrEmpty(_connection.ConnectionString))
                _connection = new TeachDbConnection().Create();
        }
    }
}

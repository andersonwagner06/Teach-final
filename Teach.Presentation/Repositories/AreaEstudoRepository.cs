using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;
using Teach_API.Results;

namespace Teach_API.Repositories
{
    public class AreaEstudoRepository : IAreaEstudoRepository
    {
        private readonly SqlConnection _connection;

        public AreaEstudoRepository()
        {
            _connection = new TeachDbConnection().Create();
        }

        public IList<AreaEstudo> ObterAreaEstudoEspecifica(int idAreaEstudoGeral)
        {
            var listagem = new List<AreaEstudo>();

            var sql = @"SELECT id_area_estudo_especifico,
                        area_especifica_descricao
                        FROM area_estudo_especifico
                        WHERE area_geral_vinculada = @areageral";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@areageral", idAreaEstudoGeral);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var area = new AreaEstudo(){
                            Id = Convert.ToInt32(reader["id_area_estudo_especifico"]),
                            Descricao = reader["area_especifica_descricao"].ToString()
                            };

                            listagem.Add(area);
                        }
                    }
                }
            }
            return listagem;
        }

        public IList<AreaEstudo> ObterAreaEstudoGeral()
        {
            var listagem = new List<AreaEstudo>();

            var sql = @"SELECT id_area_geral,
                        area_geral_descricao
                        FROM area_estudo_geral";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var area = new AreaEstudo()
                            {
                                Id = Convert.ToInt32(reader["id_area_geral"]),
                                Descricao = reader["area_geral_descricao"].ToString()
                            };

                            listagem.Add(area);
                        }
                    }
                }
            }

            return listagem;
        }
    }
}

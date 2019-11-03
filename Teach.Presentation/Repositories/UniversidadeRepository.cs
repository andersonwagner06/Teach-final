using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;

namespace Teach_API.Repositories
{
    public class UniversidadeRepository : IUniversidadeRepository
    {
        private readonly SqlConnection _connection;

        public UniversidadeRepository()
        {
            _connection = new TeachDbConnection().Create();
        }

        public IList<Universidade> ObterUniversidades()
        {
                var listagem = new List<Universidade>();

                var sql = @"SELECT id_universidade,
                        universidade
                        FROM universidades";

                using (SqlConnection connection = _connection)
                {
                    connection.Open();
                    using (var command = new SqlCommand(sql, connection))
                    {
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                var universidade = new Universidade()
                                {
                                    Id = Convert.ToInt32(reader["id_universidade"]),
                                    Descricao = reader["universidade"].ToString()
                                };

                                listagem.Add(universidade);
                            }
                        }
                    }
                }

                return listagem;
        }
    }
}

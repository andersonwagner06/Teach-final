using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Teach_API.Models;
using Teach_API.Repositories.Interfaces;

namespace Teach_API.Repositories
{
    public class IdiomaRepository : IIdiomaRepository
    {
        private readonly SqlConnection _connection;

        public IdiomaRepository()
        {
            _connection = new TeachDbConnection().Create();
        }

        public IList<Idioma> ObterIdiomas()
        {
            var listagem = new List<Idioma>();

            var sql = @"SELECT id_idioma,
                        idioma
                        FROM idiomas";

            using (SqlConnection connection = _connection)
            {
                connection.Open();
                using (var command = new SqlCommand(sql, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var idioma = new Idioma()
                            {
                                Id = Convert.ToInt32(reader["id_idioma"]),
                                Descricao = reader["idioma"].ToString()
                            };

                            listagem.Add(idioma);
                        }
                    }
                }
            }

            return listagem;
        }
    }
}

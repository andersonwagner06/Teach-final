using System.Data.SqlClient;

namespace Teach_API.Models
{
    public class TeachDbConnection
    {
        private string _connectionString;

        public TeachDbConnection()
        {
            Inicializar();
        }

        private void Inicializar()
        {
            _connectionString = string.Concat("Data Source=den1.mssql7.gear.host;User Id=teachdata;Password=Tu2u!5-l6RGs;Initial Catalog=teachdata");
        }

        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}

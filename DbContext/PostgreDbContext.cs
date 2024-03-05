using Npgsql;
using System.Data;
using web_api_practise_dotnet_core.IRepository;

namespace web_api_practise_dotnet_core.DbContext
{
    public class PostgreDbContext: IDbContext<NpgsqlCommand>
    {
        private String dbConString;
        public PostgreDbContext(IConfiguration configuration) 
        {
            NpgsqlConnectionStringBuilder builder = new NpgsqlConnectionStringBuilder();
            builder.Host = configuration.GetValue<String>("host");
            builder.Username = configuration.GetValue<String>("user");
            builder.Password = configuration.GetValue<String>("password");
            builder.Database = configuration.GetValue<String>("database");
            dbConString = builder.ToString();
        }

        private NpgsqlConnection getOpenConnection()
        {
            NpgsqlConnection con = new NpgsqlConnection(dbConString);
            con.Open();
            return con;
        }

        public int executeNonQuery(NpgsqlCommand cmd)
        {
            using ( NpgsqlConnection con  = this.getOpenConnection() )
            {
                cmd.Connection = con;
                return cmd.ExecuteNonQuery();
            }
        }

        public DataTable executeQuery(NpgsqlCommand cmd)
        {
            using ( NpgsqlConnection con = this.getOpenConnection() )
            {
                cmd.Connection = con;
                NpgsqlDataReader reader =  cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load( reader );
                return dt;           
            }
        }

    }
}

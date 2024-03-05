using System.Data;
using web_api_practise_dotnet_core.DbContext;
using web_api_practise_dotnet_core.IRepository;
using Npgsql;

namespace web_api_practise_dotnet_core.Repository
{
    public class StudentRepo : IStudentRepo
    {
        private IDbContext<NpgsqlCommand> dbContext;

        public StudentRepo(IDbContext<NpgsqlCommand> dbContext) 
        {
            this.dbContext = dbContext;
        }

        public DataTable getAllStudent()
        {
            NpgsqlCommand cmd = new NpgsqlCommand("Select name as name from student limit 10;");
            return dbContext.executeQuery(cmd);
        }
    }
}

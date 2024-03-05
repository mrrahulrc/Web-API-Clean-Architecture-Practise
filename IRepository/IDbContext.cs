using System.Data;

namespace web_api_practise_dotnet_core.IRepository
{
    public interface IDbContext<T> where T : class
    {
        int executeNonQuery(T t);
        DataTable executeQuery(T t);
    }
}

using System.Data;

namespace web_api_practise_dotnet_core.IRepository
{
    public interface IStudentRepo
    {
        DataTable getAllStudent();
    }
}

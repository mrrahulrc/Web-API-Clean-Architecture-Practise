using System.Data;
using web_api_practise_dotnet_core.IRepository;
using web_api_practise_dotnet_core.Models;

namespace web_api_practise_dotnet_core.Services
{
    public class StudentService
    {
        private IStudentRepo studentRepo;

        public StudentService(IStudentRepo studentRepo)
        {
            this.studentRepo = studentRepo;
        }

        public List<Student> getAllStudent()
        {
            using (DataTable dt = studentRepo.getAllStudent() )
            {
                return dt.AsEnumerable().Select(student =>
                {
                    return new Student()
                    {
                        name = Convert.ToString( student["name"] )
                    };
                }).ToList();
            }
        }
    }
}

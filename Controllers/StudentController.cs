using Microsoft.AspNetCore.Mvc;
using web_api_practise_dotnet_core.Services;

namespace web_api_practise_dotnet_core.Controllers
{
    public class StudentController : ControllerBase
    {
        private StudentService studentService;

        public StudentController( StudentService studentService ) 
        {
            this.studentService = studentService;
        }
        [HttpGet]
        [Route("getallstudent")]
        public IActionResult Index()
        {            
            return Ok(studentService.getAllStudent());
        }
    }
}

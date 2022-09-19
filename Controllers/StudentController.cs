using Microsoft.AspNetCore.Mvc;

namespace StudentManagementAPI.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

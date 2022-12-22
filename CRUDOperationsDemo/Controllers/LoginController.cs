using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class LoginController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public LoginController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(string email, string password)
        {
            foreach (var item in _context.users)
            {
                if (item.Email == email)
                {
                    if (item.Title == "student")
                    {
                        return RedirectToAction("Detail", "Student");
                    }
                    if (item.Title == "teacher")
                    {
                        return RedirectToAction("Attendance", "Teacher");
                    }
                    if (item.Title == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User std)
        {
            TempData["email"] = std.Email;
            foreach (var item in _context.users)
            {
                if (item.Email == std.Email)
                {
                    if (item.Title == "student")
                    {
                        return RedirectToAction("Detail", "Student");
                    }
                    if (item.Title == "teacher")
                    {
                        return RedirectToAction("Attendance", "Teacher");
                    }
                    if (item.Title == "admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                }
            }
            return View("Index");
        }
    }
}

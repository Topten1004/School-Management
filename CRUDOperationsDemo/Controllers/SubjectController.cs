using CRUDOperationsDemo;
using CRUDOperationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
namespace School.Controllers
{
    public class SubjectController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public SubjectController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }
        public IActionResult Index()
        {
            return View(_context.subjects.OrderBy(item => item.Name).ToList());
        }

        [HttpPost]
        public ActionResult Create([FromBody] Subject std)
        {
            std.DateModified = DateTime.Now;
            std.DateCreated = DateTime.Now;
            _context.subjects.Add(std);
            _context.SaveChanges();

            return Json(1);
        }

        public ActionResult Delete([FromBody] Subject std)
        {
            var result = _context.subjects.Find(std.Id);
            if (result != null)
            {
                _context.subjects.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        public IActionResult Manage()
        {
            return View();
        }
    }
}

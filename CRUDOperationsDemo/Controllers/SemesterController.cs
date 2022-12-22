using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;
using School.Models;


namespace School.Controllers
{
    public class SemesterController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public SemesterController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public ActionResult Create([FromBody]Semester semester)
        {
            semester.DateCreated = DateTime.Now;
            semester.DateModified = DateTime.Now;
            semester.ClientId = 1;
            semester.Weeks = Convert.ToInt32((semester.EndDate - semester.FromDate).TotalDays/7);
            _context.semesters.Add(semester);
            _context.SaveChanges(); 
            return Json(1);
        }
    }
}

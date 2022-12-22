using CRUDOperationsDemo;
using School.Models;
using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;

namespace School.Controllers
{
    public class EnrollmentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public EnrollmentController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [HttpPost]
        public IActionResult Access([FromBody]EnrollmentViewModel enroll)
        {
            TempData["teacherId"] = enroll.teacherId;
            return Json(true);
        }

        public IActionResult AccessSubject([FromBody]EnrollmentViewModel enroll)
        {
            TempData["teacherId"] = enroll.teacherId;
            TempData["subjectName"] = enroll.subjectName;
            return Json(true);
        }
        public IActionResult Index()
        {
            EnrollmentViewModel item = new EnrollmentViewModel();
            List<Subject> listSubjects = new List<Subject>();
            List<Enrollment> listEnrolls = new List<Enrollment>();

            int subjectId = 0;
            int teacherId = 0;
            string subjectName = string.Empty;

            if(TempData["teacherId"] != null)
                teacherId = (int)TempData["teacherId"];

            if(TempData["subjectName"] != null)
                subjectName = TempData["subjectName"] as string;

            if (teacherId == 0)
                teacherId = _context.users.First(item => item.Title == "teacher").Id;

            item.teacherId = teacherId;
            item.teacherName = _context.users.Single(item => item.Id == teacherId).FirstName + " " + _context.users.Single(item => item.Id == teacherId).LastName;
            item.users = _context.users;

            if (subjectName == "")
            {
                subjectName = _context.enrolls.FirstOrDefault(modelItem => modelItem.Teacher == item.teacherName)?.Subject ?? "";
            }

            item.subjectName = subjectName;
            foreach (var modelItem in _context.semesterTeacherSubjects)
            {
                if(modelItem.TeacherId == teacherId)
                {
                    subjectId = modelItem.SubjectId;
                    listSubjects.Add(_context.subjects.Single(temp => temp.Id == subjectId));
                }
            }

            item.subjects = listSubjects;

            foreach(var itemModel in _context.enrolls)
            {
                if(itemModel.Teacher == item.teacherName && itemModel.Subject == item.subjectName)
                {
                    listEnrolls.Add(itemModel);
                }
            }    
            item.enrolls = listEnrolls;
            return View(item);
        }

        [HttpPost]
        public ActionResult Create([FromBody] EnrollmentViewModel std)
        {
            TempData["teacherId"] = std.teacherId;
            TempData["subjectName"] = std.subjectName;

            bool flag = false;
            foreach(var item in _context.enrolls)
            {
                if(item.Student == std.enroll.Student && item.Subject == std.enroll.Subject && item.Teacher == std.enroll.Teacher)
                {
                    flag = true;
                }
            }

            if(!flag)
            {
                _context.enrolls.Add(std.enroll);
                _context.SaveChanges();
            }

            return Json(1);
        }

        public ActionResult Delete([FromBody] Enrollment std)
        {
            var result = _context.enrolls.Find(std.Id);
            if (result != null)
            {
                _context.enrolls.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
        }
}
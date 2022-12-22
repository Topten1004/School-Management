using CRUDOperationsDemo;
using CRUDOperationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using School.Models;
using System.Linq;

namespace School.Controllers
{
    public class InstructorController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public InstructorController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        public IActionResult Index()
        {
            int teacherId = 0;
            InstructorViewModel instructor = new InstructorViewModel();
            instructor.subjects = new List<Subject>();
            instructor.tsubject = new List<Subject>();
            instructor.users = new List<User>();
            instructor.teacher = new User();

            List<User> users = new List<User>();
            List<Subject> tsubjects = new List<Subject>();

            instructor.subjects = _context.subjects;
            instructor.users = _context.users;

            if (TempData["instTeacherId"] != null)
            {
                teacherId = (int)TempData["instTeacherId"];
            }

            if(teacherId == 0)
            {
                instructor.teacher = _context.users.FirstOrDefault(a => a.Title == "teacher");
                teacherId = _context.users.FirstOrDefault(a => a.Title == "teacher").Id;
            }

            instructor.teacherId = teacherId;
            foreach(var item in _context.semesterTeacherSubjects)
            {
                if(item.TeacherId == teacherId)
                {
                    Subject temp = new Subject();
                    temp = _context.subjects.Find(item.SubjectId);
                    tsubjects.Add(temp);
                }
            }

            instructor.tsubject = (IEnumerable<Subject>)tsubjects;

            Console.Write(instructor.teacher);
            return View(instructor);
        }
        
        [HttpPost]
        public IActionResult Add([FromBody]SemesterTeacherSubject temp)
        {
            temp.ClientId = 1;
            temp.SemesterId = 1;
            bool flag = false;

            foreach(var item in _context.semesterTeacherSubjects)
            {
                if(item.TeacherId == temp.TeacherId && item.SubjectId == temp.SubjectId)
                {
                    flag = true;
                }
            }
            if(flag == false)
            {
                _context.semesterTeacherSubjects.Add(temp);
            }
            _context.SaveChanges();
            TempData["instTeacherId"] = temp.TeacherId;
            return Json(true);
        }

        public IActionResult AccessTeacher([FromBody]InstructorViewModel model)
        {
            TempData["instTeacherId"] = model.teacherId;
            return Json(true);
        }

        [HttpPost]
        public IActionResult Delete([FromBody]SemesterTeacherSubject temp)
        {
            SemesterTeacherSubject deleteItem = _context.semesterTeacherSubjects.Single(item => item.SubjectId == temp.SubjectId && item.TeacherId == temp.TeacherId);
            _context.semesterTeacherSubjects.Remove(deleteItem);
            TempData["instTeacherId"] = temp.TeacherId;
            _context.SaveChanges();
            return Json(true);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using School.Models;

namespace CRUDOperationsDemo.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public List<User> students = new List<User>();

        public int weeks;
        public StudentController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;

            foreach (var item in _context.users)
            {
                if (item.Title == "student")
                {
                    students.Add(item);
                }
            }
        }

        public IActionResult Index()
        {
            return View(students.OrderBy(item => item.LastName).ToList());
        }


        [HttpPost]
        public IActionResult Access(User std)
        {
            TempData["email"] = std.Email;
            User temp = _context.users.Single(modelItem => modelItem.Email == std.Email);
            if (temp.Title == "student")
                return RedirectToAction("Detail");
            else
                return RedirectToAction("Index", "Admin");
        }

        public IActionResult Detail()
        {
            string Email = TempData["email"] as string;
            StudentPortalViewModel Viewdata = new StudentPortalViewModel();
            int studentId;
            string studentName;
            List<PointSystem> points = new List<PointSystem>();

            studentId = _context.users.Single(a => a.Email == Email).Id;
            studentName = _context.users.Single(a => a.Email == Email).FirstName + " " + _context.users.Single(a => a.Email == Email).LastName;
            Viewdata.Email = Email;
            Viewdata.Date = DateTime.Now.ToShortDateString();
            Viewdata.StudentName = studentName;
            Viewdata.Semesters = new List<Semester>();

            foreach (var item in _context.semesters)
                Viewdata.Semesters.Add(item);

            if (TempData["semester"] == null)
            {
                foreach (var item in _context.semesters)
                {
                    if (DateTime.Now >= item.FromDate && DateTime.Now <= item.EndDate)
                    {
                        Viewdata.Current_Semester = item;
                        TempData["semester"] = item.Name;
                        weeks = item.Weeks;
                    }
                }
            }

            if (TempData["semester"] != null)
            {
                foreach (var item in _context.semesters)
                {
                    string semester_value = TempData["semester"] as string;
                    if (item.Name == semester_value)
                    {
                        Viewdata.Current_Semester = item;
                        weeks = item.Weeks;
                    }
                }

                foreach (var enroll in _context.enrolls)
                {
                    if (enroll.Student == studentName)
                    {

                        PointSystem point = new PointSystem();
                        point.StudentAbsenses = new List<StudentAbsense>();

                        point.Teacher = enroll.Teacher;
                        string subject = enroll.Subject;
                        int period = 0;

                        if (_context.subjects.SingleOrDefault(a => a.Name == subject).PeriodCount != null)
                        {
                            period = _context.subjects.Single(a => a.Name == subject).PeriodCount;

                            point.Allowed = period * 15 / 10;
                            point.SubjectName = subject;
                            int missed = 0;

                            foreach (var item in _context.studentAbsenses)
                            {
                                if (item.StudentId == studentId &&
                                    (item.AbsenseType == 3 || item.AbsenseType == 4) &&
                                    enroll.Teacher == item.Teacher &&
                                    enroll.Subject == item.Subject &&
                                    (item.AuditDate >= Viewdata.Current_Semester.FromDate && item.AuditDate <= Viewdata.Current_Semester.EndDate))
                                {
                                    point.StudentAbsenses.Add(item);

                                    missed++;
                                }
                            }

                            point.Missed = missed;

                            if (missed > point.Allowed)
                                point.Deducated = point.Allowed - missed - 1;

                            points.Add(point);
                        }
                    }
                }
            }

            Viewdata.Achrayus = 102;
            foreach (var item in _context.semesterAchrayus)
            {
                if (item.Email.Contains(Viewdata.Email) &&
                    item.SemesterName.Contains(Viewdata.Current_Semester.Name))
                {
                    Viewdata.Achrayus = item.Achrayus;
                    break;
                }
            }

            Viewdata.PointSystems = points;

            return View(Viewdata);
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult List()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateStudent([FromBody] User std)
        {
            std.ClientId = _context.users.Count() + 1;
            std.Title = "student";
            std.DateModified = DateTime.Now;
            std.DateCreated = DateTime.Now;

            students.Add(std);
            _context.users.Add(std);
            _context.SaveChanges();

            return Json(1);
        }

        public ActionResult Delete([FromBody] User std)
        {
            User result = _context.users.Find(std.Id);
            string studentName = result.FirstName + " " + result.LastName;
            if (result != null)
            {
                foreach (var item in _context.enrolls)
                {
                    if (item.Student == studentName)
                    {
                        _context.Remove(item);
                    }
                }

                students.Remove(result);
                _context.users.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }

        [HttpPost]
        public IActionResult ChangeSemester([FromBody]String[] semesterItems)
        {
            if (semesterItems.Count() > 0)
            {
                foreach (var item in _context.semesters)
                {
                    if (item.Name == semesterItems[0])
                    {
                        TempData["semester"] = semesterItems[0];
                        TempData["email"] = semesterItems[1];
                        break;
                    }
                }

                return Json(true);
            }

            return View();
        }
    }
}

using CRUDOperationsDemo;
using CRUDOperationsDemo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Controllers
{
    public class AdminController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;

        public int weeks;
        public AdminController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Access()
        {
            return View();
        }

        public IActionResult accessStudent(User std)
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

        public IActionResult ChangeAchrayus([FromBody]String[] strAchrayus)
        {
            string strEmail         = strAchrayus[0];
            string strSemesterName  = strAchrayus[1];
            int nAchrayus = Int32.Parse(strAchrayus[2]);
            bool bExistAchrayus = false;

            foreach (var item in _context.semesterAchrayus)
            {
                if (item.Email.Contains( strEmail ) &&  item.SemesterName.Contains( strSemesterName ))
                {
                    item.Achrayus = nAchrayus;
                    bExistAchrayus = true;
                }
            }

            if (!bExistAchrayus)
            {
                SemesterAchrayus semesterAchrayus = new SemesterAchrayus();

                foreach (var item2 in _context.users)
                {
                    if (item2.Email == strEmail)
                    {
                        semesterAchrayus.StudentID = item2.Id;
                        break;
                    }
                }

                semesterAchrayus.Email = strEmail;
                semesterAchrayus.SemesterName = strSemesterName;
                semesterAchrayus.Achrayus = nAchrayus;

                _context.semesterAchrayus.Add(semesterAchrayus);
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Admin");
        }

        [HttpPost]
        public IActionResult ChangeSemester([FromBody] String[] semesterItems)
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

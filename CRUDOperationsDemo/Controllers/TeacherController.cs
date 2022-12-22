using Microsoft.AspNetCore.Mvc;
using CRUDOperationsDemo.Models;
using CRUDOperationsDemo;
using School.Models;

namespace School.Controllers
{
    public class TeacherController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public List<User> teachers = new List<User>();
        public TeacherController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [HttpPost]
        public IActionResult TakeAttendance([FromBody]AttendanceViewModel modelItem)
        {
            if (modelItem != null)
            {
                string date = modelItem.date.ToShortDateString();
                TempData["AttTeacherId"] = modelItem.teacherId;
                TempData["AttTeacherName"] = modelItem.teacherName;
                TempData["AttSubjectId"] = modelItem.subjectId;
                TempData["AttPeriod"] = modelItem.period;
                TempData["AttDate"] = date;
            }

            return Json(true);
        }

        public IActionResult Attendance(string subject)
        {
            var Email = TempData["email"] as string;
            AttendanceViewModel attendance = new AttendanceViewModel();
            int teacherId = _context.users.Single(item => item.Email == Email).Id;

            attendance.teacherId = teacherId;
            attendance.teacherName = _context.users.Single(model => model.Email == Email).FirstName + " " + _context.users.Single(item => item.Email == Email).LastName;

            foreach (var item in _context.semesterTeacherSubjects)
            {
                if(item.TeacherId == teacherId)
                {
                    attendance.subjects.Add(_context.subjects.Single(modelItem => modelItem.Id == item.SubjectId));
                }
            }    

            return View(attendance);
        }

        public IActionResult Edit()
        {
            foreach(var item in _context.users)
            {
                if(item.Title == "teacher")
                {
                    teachers.Add(item);
                }
            }
            if (teachers != null)
                return View(teachers.OrderBy(item => item.LastName).ToList());
            else
                return View();
        }
        public IActionResult Detail()
        {
            string teacherName = TempData["AttTeacherName"] as string;

            TeacherViewModel Viewitem = new TeacherViewModel();
            List<string> studentNames = new List<string>();
            List<User> users = new List<User>();

            string subject = "";
            int teacherId = (int)TempData["AttTeacherId"];
            int subjectId = (int)TempData["AttSubjectId"];
            Viewitem.date = TempData["AttDate"] as string;
            Viewitem.subject = _context.subjects.Single(a => a.Id == subjectId).Name;

            Viewitem.name = _context.users.Find(teacherId).FirstName+ " "+ _context.users.Find(teacherId).LastName;
            Viewitem.period = (int)TempData["AttPeriod"];// _context.subjects.Single(a => a.Id == subjectId).PeriodCount;

            //_context.subjects.Single(a => a.Id == subjectId).PeriodCount = Viewitem.period;
            subject = _context.subjects.Single(a => a.Id == subjectId).Name;

            foreach (var item in _context.enrolls)
            {
                if( item.Teacher == Viewitem.name &&
                    item.Subject == Viewitem.subject )
                {
                    studentNames.Add(item.Student);
                }
            }

            foreach(var item in studentNames)
            {
                foreach(var st in _context.users)
                {
                    string fullName = st.FirstName + " " + st.LastName;
                    if(fullName == item)
                    {
                        users.Add(st);
                    }
                }
            }

            Viewitem.students = users;
            Viewitem.subject = subject;

            bool bExistSubject = false;
            foreach (var item in _context.subjectAttendance)
            {
                if (item.SubjectId == subjectId && 
                    item.TeacherId == teacherId &&
                    item.Date.ToString().Contains(Viewitem.date) )
                {
                    SubjectAttendance itemSubjectAttenance = new SubjectAttendance();
                    itemSubjectAttenance.TeacherId = teacherId;
                    itemSubjectAttenance.SubjectId = subjectId;
                    itemSubjectAttenance.Date = DateTime.Parse(Viewitem.date);
                    itemSubjectAttenance.Period = (int)TempData["AttPeriod"];
                    itemSubjectAttenance.PeriodTimeOfDay = item.PeriodTimeOfDay + 1;
                    _context.subjectAttendance.Add(itemSubjectAttenance);

                    bExistSubject = true;
                    break;
                }
            }

            if (!bExistSubject)
            {
                SubjectAttendance itemSubjectAttenance = new SubjectAttendance();
                itemSubjectAttenance.TeacherId = teacherId;
                itemSubjectAttenance.SubjectId = subjectId;
                itemSubjectAttenance.Date = DateTime.Parse(Viewitem.date);
                itemSubjectAttenance.Period = (int)TempData["AttPeriod"];
                itemSubjectAttenance.PeriodTimeOfDay = 1;

                _context.subjectAttendance.Add(itemSubjectAttenance);
            }

            _context.SaveChanges();
            return View(Viewitem);
        }

        [HttpPost]
        public ActionResult Create([FromBody] User std)
        {
            std.ClientId = _context.users.Count() + 1;
            std.Title = "teacher";
            std.DateModified = DateTime.Now;
            std.DateCreated = DateTime.Now;
            teachers.Add(std);
            _context.users.Add(std);
            _context.SaveChanges();

            return Json(1);
        }

        public ActionResult Delete([FromBody] User std)
        {
            var result = _context.users.Find(std.Id);
            if (result != null)
            {
                teachers.Remove(result);
                _context.users.Remove(result);
                _context.SaveChanges();
            }
            return Json(1);
        }
    }
}

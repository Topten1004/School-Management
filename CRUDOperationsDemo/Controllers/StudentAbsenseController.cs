using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;
using School.Models;

namespace School.Controllers
{
    public class StudentAbsenseController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public StudentAbsenseController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [HttpPost]
        public ActionResult CreateAbsense([FromBody]List<StudentAbsense> logItems)
        {
            foreach(var std in logItems)
            {
                std.AuditDate = DateTime.Now;
                bool flag = false;

                foreach (var item in _context.studentAbsenses)
                {
                    if (item.StudentId == std.StudentId && (item.Subject == std.Subject && item.Teacher == std.Teacher) && item.Date == std.Date)
                    {
                        item.AbsenseType = std.AbsenseType;
                        item.Note = std.Note;
                        item.Date = std.Date;

                        flag = true;
                    }
                }

                if (flag == false)
                {
                    int subjectId = (int)_context.subjects.Single(a => a.Name == std.Subject).Id;
                    List<int> lstPeriod = new List<int>();


                    foreach (var item in _context.subjectAttendance)
                    { 
                        if (item.SubjectId == subjectId &&
                            item.Date.ToShortDateString() == std.AuditDate.ToShortDateString())
                        {
                            lstPeriod.Add(item.PeriodTimeOfDay);
                        }
                    }

                    int nPeriodTimeOfDay = 0;
                    for (int i = 0; i < lstPeriod.Count; i++)
                    {
                        if (lstPeriod[i] > nPeriodTimeOfDay)
                            nPeriodTimeOfDay = lstPeriod[i];
                    }

                    std.PeriodTimeOfDay = nPeriodTimeOfDay;
                    _context.studentAbsenses.Add(std);
                }
            }
            _context.SaveChanges();
            return Json(1);
        }
    }
}

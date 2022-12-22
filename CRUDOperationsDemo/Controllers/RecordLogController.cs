using CRUDOperationsDemo;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using School.Models;
using System;

namespace School.Controllers
{
    public class RecordLogController : Controller
    {
        private readonly SchoolDbContext _context;
        private readonly IWebHostEnvironment env;
        public RecordLogController(SchoolDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            this.env = env;
        }

        [HttpPost]
        public IActionResult ChangeDate([FromBody] DateTime date)
        {
            TempData["date"] = date;
            return Json(true);
        }

        [HttpPost]
        public IActionResult SaveRecord([FromBody]RecordLogItem[] logs)

        {
            foreach(var item in logs)
            {
                _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).Note = item.note;

                if (item.type == "Present")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 1;
                else if (item.type == "Late")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 2;
                else if (item.type == "Absent Unexcused")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 3;
                else if (item.type == "Absent Excused")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 4;
                else if (item.type == "Mandated Absence")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 5;
                else if (item.type == "Excused Late")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 6;
                else if (item.type == "Infraction")
                    _context.studentAbsenses.Single(modelItem => modelItem.Id == item.Id).AbsenseType = 7;
            }

            _context.SaveChanges();
            return Json(true);
        }
        public IActionResult Index()
        {
            DateTime toDate = DateTime.Now.Date;
            if(TempData["date"] != null)
            {
                toDate = Convert.ToDateTime(TempData["date"].ToString());
            }

            List<RecordLogItem> absenses = new List<RecordLogItem>();
            List<SubjectAttendance> subjectAttendances = new List<SubjectAttendance>();
            RecordLogViewModel record = new RecordLogViewModel();
            record.semester = "Semester";

            foreach (var semester_item in _context.semesters)
            {
                if (toDate.Date >= semester_item.FromDate && toDate.Date <= semester_item.EndDate)
                {
                    record.semester = semester_item.Name;
                    break;
                }
            }

            foreach (var item in _context.studentAbsenses)
            {
                if( item.AuditDate.ToShortDateString() == toDate.ToShortDateString() &&
                    (item.AbsenseType != 1))
                {
                    RecordLogItem temp = new RecordLogItem();

                    temp.types.Add("Absent Excused");
                    temp.types.Add("Absent Unexcused");
                    temp.types.Add("Mandated Absence");
                    temp.types.Add("Excused Late");
                    temp.types.Add("Infraction");
                    temp.types.Add("Late");
                    temp.types.Add("Present");

                    if (item.AbsenseType == 2) temp.type = "Late"; 
                    if (item.AbsenseType == 3) temp.type = "Absent Unexcused";
                    if (item.AbsenseType == 4) temp.type = "Absent Excused"; 
                    if (item.AbsenseType == 5) temp.type = "Mandated Absence"; 
                    if (item.AbsenseType == 6) temp.type = "Excused Late"; 
                    if (item.AbsenseType == 7) temp.type = "Infraction";

                    temp.Id = item.Id;
                    temp.teacher = item.Teacher;
                    temp.note = item.Note;
                    if (temp.note == "" || temp.note == null)
                        temp.isNote = false;
                    
                    temp.subject = item.Subject;
                    temp.student = _context.users.Find(item.StudentId).FirstName + " " + _context.users.Find(item.StudentId).LastName;

                    int? subjectId = _context.subjects.Single(a => a.Name == item.Subject).Id;
                    int teacherId = _context.users.Single(a => (a.FirstName + " " + a.LastName) == item.Teacher).Id;

                    foreach (var subject_item in _context.subjectAttendance)
                    {
                        if (subject_item.TeacherId == teacherId &&
                            subject_item.SubjectId == subjectId &&
                            subject_item.PeriodTimeOfDay == item.PeriodTimeOfDay)
                        {
                            temp.period = subject_item.Period;
                            break;
                        }
                    }

                    temp.periodtimeofday = item.PeriodTimeOfDay;

                    absenses.Add(temp);
                }
            }

            record.date = toDate;
            record.dayOfWeek = toDate.DayOfWeek.ToString();
            record.records = absenses;

            return View(record);
        }
    }
}

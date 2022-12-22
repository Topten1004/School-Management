using CRUDOperationsDemo.Models;

namespace School.Models
{
    public class AttendanceViewModel
    {
        public string teacherName { get; set; } = string.Empty;

        public int teacherId { get; set;} = 0;
        public List<Subject> subjects { get; set; } = new List<Subject>();

        public List<int> periods { get; set; } = new List<int> { 0 };

        public string subject { get; set; } = string.Empty;

        public int period { get ; set; } = 0;
        public int subjectId { get; set; } = 0;
        public DateTime date { get; set; } = DateTime.Now;
    }
}

using CRUDOperationsDemo.Models;

namespace School.Models
{
    public class EnrollmentViewModel
    {
        public int teacherId { get; set; } = 0;

        public string teacherName { get; set; } = string.Empty;

        public string subjectName { get; set;} = string.Empty;
        public IEnumerable<User> users { get; set; } = new List<User>();

        public IEnumerable<Subject> subjects { get; set; } = new List<Subject>();

        public IEnumerable<Enrollment> enrolls { get; set; } = new List<Enrollment>();

        public Enrollment enroll { get; set;  } = new Enrollment(); 
    }
}

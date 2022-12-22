using CRUDOperationsDemo.Models;

namespace School.Models
{
    public class InstructorViewModel
    {
        public User teacher { get; set; } = new User();

        public string teacherName { get; set; } = string.Empty;

        public int teacherId { get; set; } = 0;
        public IEnumerable<User> users { get; set; } = new List<User>();

        public IEnumerable<Subject> subjects { get; set; } = new List<Subject>();

        public IEnumerable<Subject> tsubject { get; set; } = new List<Subject>();
    }
}

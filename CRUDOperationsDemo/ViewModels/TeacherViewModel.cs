using CRUDOperationsDemo.Models;

namespace School.Models
{
    public class TeacherViewModel
    {
        public string name { get; set; } = string.Empty;

        public string subject { get; set; } = string.Empty;

        public int period { get; set; } = 0;

        public string date { get; set; }

        public IEnumerable<User> students { get; set; }
    }
}

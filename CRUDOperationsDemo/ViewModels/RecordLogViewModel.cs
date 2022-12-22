namespace School.Models
{
    public class RecordLogViewModel
    {
        public string dayOfWeek { get; set; } = String.Empty;

        public DateTime date { get; set; } = DateTime.Now;

        public string semester { get; set; } = String.Empty;

        public IEnumerable<RecordLogItem> records { get; set; } = new List<RecordLogItem>();
    }

    public class RecordLogItem
    {
        public int Id { get; set; }

        public string subject { get; set; } = String.Empty;

        public string teacher { get; set; } = String.Empty;

        public int period { get;set; } = 0;

        public List<string> types { get; set; } = new List<string>();

        public string type { get; set; } = String.Empty;

        public string student { get; set; } = String.Empty; 

        public bool isNote { get; set; } = true;

        public string note { get; set; } = String.Empty;

        public int periodtimeofday { get; set; } = 0;
    }
}

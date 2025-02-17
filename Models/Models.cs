using SQLite;

namespace WGU_MobileDevelopment_JMBenitez.Models
{
    public class Term   
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

    public class Course
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int TermId { get; set; }  // Foreign key to Term
        public string Title { get; set; } = string.Empty;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; } = string.Empty;  // e.g., "In Progress", "Completed", etc.
        public string InstructorName { get; set; } = string.Empty;
        public string InstructorPhone { get; set; } = string.Empty;
        public string InstructorEmail { get; set; } = string.Empty;
        public string Notes { get; set; } = string.Empty;

    }

    public enum AssessmentType
    {
        Objective,
        Performance
    }
    public class Assessment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CourseId { get; set; }  // Foreign key to Course
        public AssessmentType Type { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
    }
}

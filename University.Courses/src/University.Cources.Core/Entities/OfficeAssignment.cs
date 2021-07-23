namespace University.Cources.Core.Entities
{
    public class OfficeAssignment
    {
        public int InstructorId { get; set; }
        public string Location { get; set; }
        public Instructor Instructor { get; set; }
    }
}
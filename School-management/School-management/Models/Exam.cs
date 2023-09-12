namespace School_management.Models
{
    public class Exam
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ICollection<Question> Questions { get; set; }
    }
}

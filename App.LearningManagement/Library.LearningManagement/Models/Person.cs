namespace Library.LearningManagement.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Dictionary<int, double> Grades { get; set; }

        public char Classification { get; set; }

        public Person()
        {
            Name = string.Empty;
            Grades = new Dictionary<int, double>();
        }
    }
}
namespace Library.LearningManagement.Models
{
    public class Person
    {
        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }

        public string Name { get; set; }

        public Person()
        {
            Name = string.Empty;
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}";
        }
    }
}
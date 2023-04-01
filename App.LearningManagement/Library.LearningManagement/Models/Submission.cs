using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Submission
    {
        private static int lastId = 0;
        public int Id
        {
            get; private set;
        }

        public Student Student { get; set; }
        public Assignment Assignment { get; set; }
        public string Content { get; set; }

        public Submission()
        {
            Id = ++lastId;
            Content = string.Empty;
        }

        public override string ToString()
        {
            return $"[{Id}]{Student.Name}: {Assignment}";
        }
    }
}

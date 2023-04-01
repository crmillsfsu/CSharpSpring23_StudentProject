using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Assignment
    {
        private static int lastId = 0;
        public int Id
        {
            get; private set;
        }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal TotalAvailablePoints { get; set; }
        public DateTime DueDate { get; set; }

        public Assignment()
        {
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"{Id}. ({DueDate}) {Name}";
        }
    }
}

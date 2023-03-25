using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class AssignmentGroup
    {
        public List<Assignment> Assignments { get; set; }
        public int Id { get; private set; }
        private static int lastId;

        public string Name { get; set; }
        public decimal Weight { get; set; }

        public AssignmentGroup() { 
            Assignments = new List<Assignment>();
            Name = string.Empty;
            Weight = 1;

            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name} ({Weight}%)\n{string.Join("\n", Assignments.Select(s => s.ToString()).ToArray())}";
        }
    }
}

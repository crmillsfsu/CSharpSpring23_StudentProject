using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class Announcement
    {
        private static int lastId = 0;
        public string? Name { get; set; }
        public string? Description { get; set; }
        public int Id
        {
            get; private set;
        }

        public Announcement()
        {
            Id = ++lastId;
        }

        public override string ToString()
        {
            return $"[{Id}] {Name}: {Description}";
        }
    }
}

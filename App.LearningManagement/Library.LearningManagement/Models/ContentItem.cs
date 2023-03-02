using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class ContentItem
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Models
{
    public class ContentItem
    {
        private static int lastId = 0;

        public int Id
        {
            get; private set;
        }
        public string? Name { get; set; }
        public string? Description { get; set; }

        public override string ToString()
        {
            return $"{Name}: {Description}";
        }

        public ContentItem()
        {
            Id = ++lastId;
        }
    }
}

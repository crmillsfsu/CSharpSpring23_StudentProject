using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.LearningManagement.Helpers
{
    public class CourseHelper
    {
        private CourseService courseService = new CourseService();
        private StudentService studentService = new StudentService();

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            Console.WriteLine("What is the code of the course?");
            var code = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the name of the course?");
            var name = Console.ReadLine() ?? string.Empty;
            Console.WriteLine("What is the description of the course?");
            var description = Console.ReadLine() ?? string.Empty;

            Console.WriteLine("Which students should be enrolled in this course? ('Q' to quit)");
            var roster = new List<Person>();
            bool continueAdding = true;
            while(continueAdding)
            {
                studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                var selection = Console.ReadLine() ?? string.Empty;

                if(selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = false;
                } else
                {
                    var selectedId = int.Parse(selection);
                    var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);

                    if(selectedStudent != null)
                    {
                        roster.Add(selectedStudent);
                    }
                }
            }


            bool isNewCourse = false;
            if(selectedCourse == null)
            {
                isNewCourse= true;
                selectedCourse = new Course();
            }

            selectedCourse.Code = code;
            selectedCourse.Name = name;
            selectedCourse.Description = description;
            selectedCourse.Roster = new List<Person>();
            selectedCourse.Roster.AddRange(roster);

            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }

        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update:");
            ListCourses();

            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
        }

        public void ListCourses()
        {
            courseService.Courses.ForEach(Console.WriteLine);

        }

        public void SearchCourses()
        {
            Console.WriteLine("Enter a query:");
            var query = Console.ReadLine() ?? string.Empty;

            courseService.Search(query).ToList().ForEach(Console.WriteLine);
        }
    }
}

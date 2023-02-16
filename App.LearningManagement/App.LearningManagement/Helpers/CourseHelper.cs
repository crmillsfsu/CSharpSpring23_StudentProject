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
        private CourseService courseService;
        private StudentService studentService;

        public CourseHelper()
        {
            studentService= StudentService.Current;
            courseService = CourseService.Current;
        }

        public void CreateCourseRecord(Course? selectedCourse = null)
        {
            bool isNewCourse = false;
            if (selectedCourse == null)
            {
                isNewCourse = true;
                selectedCourse = new Course();
            }

            var choice = "Y";
            if (!isNewCourse)
            {
                Console.WriteLine("Do you want to update the course code?");
                choice = Console.ReadLine() ?? "N";
            }

            if(choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the code of the course?");
                selectedCourse.Code = Console.ReadLine() ?? string.Empty;
            }

            if(!isNewCourse)
            {
                Console.WriteLine("Do you want to update the course name?");
                choice = Console.ReadLine() ?? "N";
            } else
            {
                choice = "Y";
            }
            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the name of the course?");
                selectedCourse.Name = Console.ReadLine() ?? string.Empty;
            }

            if(!isNewCourse)
            {
                Console.WriteLine("Do you want to update the course description?");
                choice = Console.ReadLine() ?? "N";
            } else
            {
                choice = "Y";
            }
            if (choice.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
            {
                Console.WriteLine("What is the description of the course?");
                selectedCourse.Description = Console.ReadLine() ?? string.Empty;
            }

            if (isNewCourse)
            {
                var roster = new List<Person>();
                var assignments = new List<Assignment>();
                Console.WriteLine("Which students should be enrolled in this course? ('Q' to quit)");
                bool continueAdding = true;
                while (continueAdding)
                {
                    studentService.Students.Where(s => !roster.Any(s2 => s2.Id == s.Id)).ToList().ForEach(Console.WriteLine);
                    var selection = "Q";
                    if (studentService.Students.Any(s => !roster.Any(s2 => s2.Id == s.Id)))
                    {
                        selection = Console.ReadLine() ?? string.Empty;
                    }

                    if (selection.Equals("Q", StringComparison.InvariantCultureIgnoreCase))
                    {
                        continueAdding = false;
                    }
                    else
                    {
                        var selectedId = int.Parse(selection);
                        var selectedStudent = studentService.Students.FirstOrDefault(s => s.Id == selectedId);

                        if (selectedStudent != null)
                        {
                            roster.Add(selectedStudent);
                        }
                    }
                }

                Console.WriteLine("Would you like to add assignments? (Y/N)");
                var assignResponse = Console.ReadLine() ?? "N";

                if (assignResponse.Equals("Y", StringComparison.InvariantCultureIgnoreCase))
                {
                    continueAdding = true;
                    while (continueAdding)
                    {
                        //Name
                        Console.WriteLine("Name:");
                        var assignmentName = Console.ReadLine() ?? string.Empty;
                        //Description
                        Console.WriteLine("Description:");
                        var assignmentDescription = Console.ReadLine() ?? string.Empty;
                        //TotalPoints
                        Console.WriteLine("TotalPoints:");
                        var totalPoints = decimal.Parse(Console.ReadLine() ?? "100");
                        //DueDate
                        Console.WriteLine("DueDate:");
                        var dueDate = DateTime.Parse(Console.ReadLine() ?? "01/01/1900");

                        assignments.Add(new Assignment
                        {
                            Name = assignmentName,
                            Description = assignmentDescription,
                            TotalAvailablePoints = totalPoints,
                            DueDate = dueDate
                        });

                        Console.WriteLine("Add more courses? (Y/N)");
                        assignResponse = Console.ReadLine() ?? "N";
                        if (assignResponse.Equals("N", StringComparison.InvariantCultureIgnoreCase))
                        {
                            continueAdding = false;
                        }
                    }
                }

                selectedCourse.Roster = new List<Person>();
                selectedCourse.Roster.AddRange(roster);
                selectedCourse.Assignments = new List<Assignment>();
                selectedCourse.Assignments.AddRange(assignments);
            }
            
            
            if(isNewCourse)
            {
                courseService.Add(selectedCourse);
            }

        }

        public void UpdateCourseRecord()
        {
            Console.WriteLine("Enter the code for the course to update:");
            courseService.Courses.ForEach(Console.WriteLine);
            var selection = Console.ReadLine();

            var selectedCourse = courseService.Courses.FirstOrDefault(s => s.Code.Equals(selection, StringComparison.InvariantCultureIgnoreCase));
            if (selectedCourse != null)
            {
                CreateCourseRecord(selectedCourse);
            }
        }

        public void SearchCourses(string? query = null)
        {
            if(string.IsNullOrEmpty(query))
            {
                courseService.Courses.ForEach(Console.WriteLine);
            } else
            {
                courseService.Search(query).ToList().ForEach(Console.WriteLine);
            }

            Console.WriteLine("Select a course:");
            var code = Console.ReadLine() ?? string.Empty;

            var selectedCourse = courseService
                .Courses
                .FirstOrDefault(c => c.Code.Equals(code, StringComparison.InvariantCultureIgnoreCase));
            if(selectedCourse != null)
            {
                Console.WriteLine(selectedCourse.DetailDisplay);
            }
        }
    }
}

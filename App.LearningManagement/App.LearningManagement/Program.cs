using App.LearningManagement.Helpers;
using Library.LearningManagement.Models;
using System.Xml;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var studentHelper = new StudentHelper();
            var courseHelper = new CourseHelper();
            bool cont = true;

            while (cont)
            {
                Console.WriteLine("Choose an action:");
                Console.WriteLine("1. Add a student enrollment");
                Console.WriteLine("2. Update a student enrollment");
                Console.WriteLine("3. List all enrolled students");
                Console.WriteLine("4. Search for a student");
                Console.WriteLine("5. Add a new course");
                Console.WriteLine("6. Update a course");
                Console.WriteLine("7. List all courses");
                Console.WriteLine("8. Exit");
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result)) {

                    if (result == 1)
                    {
                        studentHelper.CreateStudentRecord();
                    } else if (result == 2)
                    {
                        studentHelper.UpdateStudentRecord();
                    } else if (result == 3)
                    {
                        studentHelper.ListStudents();
                    } else if (result ==4)
                    {
                        studentHelper.SearchStudents();
                    } else if (result == 5) {
                        courseHelper.CreateCourseRecord();
                    } else if (result == 6)
                    {
                        courseHelper.UpdateCourseRecord();
                    } 
                    else if (result ==7)
                    {
                        courseHelper.ListCourses();
                    } else if (result == 8)
                    {
                        cont = false;
                    }
                }

            }

        }
    }
}
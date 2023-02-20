using App.LearningManagement.Helpers;

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
                Console.WriteLine("1. Maintain People");
                Console.WriteLine("2. Maintain Courses");
                Console.WriteLine("3. Exit");                           //sys
                var input = Console.ReadLine();
                if (int.TryParse(input, out int result)) {
                    if (result == 1)
                    {
                        ShowStudentMenu(studentHelper);
                    } else if(result == 2)
                    {
                        ShowCourseMenu(courseHelper);
                    }
                    else if (result == 3)
                    {
                        cont = false;
                    }
                }

            }

        }
        
        static void ShowStudentMenu(StudentHelper studentHelper)
        {
            Console.WriteLine("Choose an action:");
            Console.WriteLine("1. Add a new person");       
            Console.WriteLine("2. Update a person");    
            Console.WriteLine("3. List all people");     
            Console.WriteLine("4. Search for a person");           

            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    studentHelper.CreateStudentRecord();
                }
                else if (result == 2)
                {
                    studentHelper.UpdateStudentRecord();
                }
                else if (result == 3)
                {
                    studentHelper.ListStudents();
                }
                else if (result == 4)
                {
                    studentHelper.SearchStudents();
                }
            }
        }

        static void ShowCourseMenu(CourseHelper courseHelper)
        {
            Console.WriteLine("1. Add a new course");               //course
            Console.WriteLine("2. Update a course");                //course
            Console.WriteLine("3. Add a student to a course");
            Console.WriteLine("4. Remove a student from a course");
            Console.WriteLine("5. Add an assignment");
            Console.WriteLine("6. Update an assignment");
            Console.WriteLine("7. Remove an assignment");
            Console.WriteLine("8. List all courses");               //course
            Console.WriteLine("9. Search for a course");            //course


            var input = Console.ReadLine();
            if (int.TryParse(input, out int result))
            {
                if (result == 1)
                {
                    courseHelper.CreateCourseRecord();
                }
                else if (result == 2)
                {
                    courseHelper.UpdateCourseRecord();
                } else if(result == 3)
                {
                    courseHelper.AddStudent();
                }
                else if (result == 4)
                {
                    courseHelper.RemoveStudent();
                }
                else if (result == 5)
                {
                    courseHelper.AddAssignment();
                } else if(result == 6)
                {
                    courseHelper.UpdateAssignment();
                } else if (result == 7)
                {
                    courseHelper.RemoveAssignment();
                }
                else if (result == 8)
                {
                    courseHelper.SearchCourses();
                }
                else if (result == 9)
                {
                    Console.WriteLine("Enter a query:");
                    var query = Console.ReadLine() ?? string.Empty;
                    courseHelper.SearchCourses(query);
                }
            }
        }
    }
}
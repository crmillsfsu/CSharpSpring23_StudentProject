using Library.LearningManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Services
{
    public class StudentService
    {
        private List<Person> studentList;

        private static StudentService? _instance;

        private StudentService()
        {
            studentList = new List<Person>();
        }

        public static StudentService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new StudentService();
                }

                return _instance;
            }
        }

        public void Add(Person student)
        {
            studentList.Add(student);
        }

        public List<Person> Students
        {
            get
            {
                return studentList;
            }
        }

        public IEnumerable<Person> Search(string query)
        {
            return studentList.Where(s => s.Name.ToUpper().Contains(query.ToUpper()));
        }

        public decimal GetGPA(int studentId)
        {
            var courseSvc = CourseService.Current;
            var courses = courseSvc.Courses.Where(c => c.Roster.Select(s => s.Id).Contains(studentId));

            var totalGradePoints = courses.Select(c => courseSvc.GetGradePoints(c.Id, studentId) * c.CreditHours).Sum();
            var totalCreditHours = courses.Select(c => c.CreditHours).Sum();

            return totalGradePoints / (totalCreditHours > 0 ? totalCreditHours : -1);
        }
    }
}

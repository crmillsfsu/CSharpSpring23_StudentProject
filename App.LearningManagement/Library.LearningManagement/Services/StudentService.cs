using Library.LearningManagement.Database;
using Library.LearningManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Services
{
    public class StudentService
    {

        private static StudentService? _instance;

        public IEnumerable<Student?> Students
        {
            get 
            {
                return FakeDatabase.People.Where(p => p is Student).Select(p => p as Student);
            }
        }

        private StudentService()
        {
            
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
            FakeDatabase.People.Add(student);
        }

        public void Remove(Person student)
        {
            FakeDatabase.People.Remove(student);
        }

        public Person? GetById(int id)
        {
            return FakeDatabase.People.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Student?> Search(string query)
        {
            return Students.Where(s => (s != null) && s.Name.ToUpper().Contains(query.ToUpper()));
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

using Library.LearningManagement.Database;
using Library.LearningManagement.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.LearningManagement.Services
{
    public class CourseService
    {
        private static CourseService? _instance;

        public static CourseService Current
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new CourseService();
                }

                return _instance;
            }
        }

        private CourseService()
        {

        }

        public void Add(Course course)
        {
            FakeDatabase.Courses.Add(course);
        }

        public List<Course> Courses
        {
            get
            {
                return FakeDatabase.Courses;
            }
        }

        public IEnumerable<Course> Search(string query)
        {
            return Courses.Where(s => s.Name.ToUpper().Contains(query.ToUpper())
                || s.Description.ToUpper().Contains(query.ToUpper())
                || s.Code.ToUpper().Contains(query.ToUpper()));
        }

        public decimal GetWeightedGrade(int courseId, int studentId)
        {
            var selectedCourse = Courses.FirstOrDefault(c => c.Id == courseId);
            if(selectedCourse == null)
            {
                return -1M;
            }

            var weightedAverage = 0M;
            foreach (var group in selectedCourse.AssignmentGroups)
            {
                var submissions = selectedCourse.Submissions
                    .Where(s => s.Student.Id == studentId
                        && group.Assignments.Select(a => a.Id).Contains(s.Assignment.Id));
                if (submissions.Any())
                {
                    weightedAverage += submissions.Select(s => s.Grade).Average() * group.Weight;
                }
            }

            return weightedAverage;
        }

        public decimal GetGradePoints(int courseId, int studentId)
        {
            return GetGradePoints(GetWeightedGrade(courseId, studentId));
        }

        public string GetLetterGrade(decimal grade)
        {
            if (grade >= 93)
            {
                return "A";
            }
            else if (grade < 93 && grade >= 90)
            {
                return "A-";
            }
            else if (grade < 90 && grade >= 87)
            {
                return "B+";
            }
            else if (grade < 87 && grade >= 83)
            {
                return "B";
            }
            else if (grade < 83 && grade >= 80)
            {
                return "B-";
            }
            else if (grade < 80 && grade >= 77)
            {
                return "C+";
            }
            else if (grade < 77 && grade >= 73)
            {
                return "C";
            }
            else if (grade < 73 && grade >= 70)
            {
                return "C-";
            }
            else if (grade < 70 && grade >= 60)
            {
                return "D";
            }
            else
            {
                return "F";
            }

        }

        public decimal GetGradePoints(decimal grade)
        {
            if (grade >= 93)
            {
                return 4M;
            }
            else if (grade < 93 && grade >= 90)
            {
                return 3.7M;
            }
            else if (grade < 90 && grade >= 87)
            {
                return 3.3M;
            }
            else if (grade < 87 && grade >= 83)
            {
                return 3M;
            }
            else if (grade < 83 && grade >= 80)
            {
                return 2.7M;
            }
            else if (grade < 80 && grade >= 77)
            {
                return 2.3M;
            }
            else if (grade < 77 && grade >= 73)
            {
                return 2M;
            }
            else if (grade < 73 && grade >= 70)
            {
                return 1.7M;
            }
            else if (grade < 70 && grade >= 60)
            {
                return 1M;
            }
            else
            {
                return 0M;
            }
        }

    }
}

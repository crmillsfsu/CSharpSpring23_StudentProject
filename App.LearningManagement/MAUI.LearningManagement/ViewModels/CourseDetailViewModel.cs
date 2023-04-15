using Library.LearningManagement.Models;
using Library.LearningManagement.Services;


namespace MAUI.LearningManagement.ViewModels
{
    class CourseDetailViewModel
    {
        public CourseDetailViewModel() { 
            course = new Course();
        }

        public string Name { 
            get=> course?.Name ?? string.Empty;
            set { if (course != null) course.Name = value; }
        }
        public string Description {
            get => course?.Description ?? string.Empty;
            set { if (course != null) course.Description = value; }
        }
        public string Prefix {
            get => course?.Prefix ?? string.Empty;
            set { if (course != null) course.Prefix = value; }
        }
        public int Id { get; set; }

        public string CourseCode {
            get => course?.Code ?? string.Empty;
        }

        private Course course;

        public void AddCourse(Shell s)
        {
            CourseService.Current.Add(course);
            s.GoToAsync("//Instructor");
        }

    }
}

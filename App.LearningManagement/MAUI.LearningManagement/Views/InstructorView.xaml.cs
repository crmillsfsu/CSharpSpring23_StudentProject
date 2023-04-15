using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class InstructorView : ContentPage
{
	public InstructorView()
	{
		InitializeComponent();
		BindingContext = new InstructorViewViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//MainPage");
    }

    private void AddEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RefreshView();
    }

    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveEnrollmentClick();
    }

    private void EditEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddEnrollmentClick(Shell.Current);
    }

    private void AddCourseClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddCourseClick(Shell.Current);
    }

    private void Toolbar_EnrollmentsClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowEnrollments();
    }

    private void Toolbar_CoursesClicked(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).ShowCourses();
    }
}
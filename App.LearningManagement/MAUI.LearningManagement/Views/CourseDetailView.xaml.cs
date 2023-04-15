using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class CourseDetailView : ContentPage
{
	public CourseDetailView()
	{
		InitializeComponent();
		BindingContext = new CourseDetailViewModel();
	}

    private void CancelClicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OkClicked(object sender, EventArgs e)
    {
        (BindingContext as CourseDetailViewModel).AddCourse(Shell.Current);
    }
}
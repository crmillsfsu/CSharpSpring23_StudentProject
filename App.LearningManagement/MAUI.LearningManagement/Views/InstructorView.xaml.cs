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
        (BindingContext as InstructorViewViewModel).AddClick(Shell.Current);
    }

    private void ContentPage_NavigatedTo(object sender, NavigatedToEventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RefreshView();
    }
<<<<<<< HEAD
<<<<<<< Updated upstream
=======
=======
>>>>>>> 3ec7ec54ce42b3c38e38ee5b2bc0af9f77aee2ae

    private void RemoveEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).RemoveClick();
    }
<<<<<<< HEAD

    private void EditEnrollmentClick(object sender, EventArgs e)
    {
        (BindingContext as InstructorViewViewModel).AddClick(Shell.Current);
    }
>>>>>>> Stashed changes
=======
>>>>>>> 3ec7ec54ce42b3c38e38ee5b2bc0af9f77aee2ae
}
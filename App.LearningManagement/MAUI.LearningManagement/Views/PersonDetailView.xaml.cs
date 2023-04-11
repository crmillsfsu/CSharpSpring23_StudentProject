using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

[QueryProperty(nameof(PersonId), "personId")]
public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();
	}

    public int PersonId
    {
        set; get;
    }

    private void OkClick(object sender, EventArgs e)
    {
		(BindingContext as PersonDetailViewModel).AddPerson();
    }

    private void CancelClick(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync("//Instructor");
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = null;
    }

	private void OnArriving(object sender, NavigatedToEventArgs e) {
        BindingContext = new PersonDetailViewModel(PersonId);
    }
}
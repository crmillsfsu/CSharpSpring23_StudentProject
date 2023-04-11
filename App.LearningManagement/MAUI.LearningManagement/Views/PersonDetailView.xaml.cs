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

    private void OkClick(object sender, EventArgs e)
    {
		//TODO: Need to migrate this to the ViewModel
		(BindingContext as PersonDetailViewModel).AddPerson();
        
    }

    private void OnLeaving(object sender, NavigatedFromEventArgs e)
    {
		BindingContext = null;
    }

	private void OnArriving(object sender, NavigatedToEventArgs e) {
        BindingContext = new PersonDetailViewModel();
    }
}
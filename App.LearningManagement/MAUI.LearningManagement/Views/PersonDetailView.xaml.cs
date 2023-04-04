using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using MAUI.LearningManagement.ViewModels;

namespace MAUI.LearningManagement.Views;

public partial class PersonDetailView : ContentPage
{
	public PersonDetailView()
	{
		InitializeComponent();

		BindingContext = new PersonDetailViewModel();
	}

    private void OkClick(object sender, EventArgs e)
    {
		//TODO: Need to migrate this to the ViewModel
		var context = BindingContext as PersonDetailViewModel;
		PersonClassification classification;
		switch (context.ClassificationString)
		{
			case "S":
				classification = PersonClassification.Senior;
				break;
			case "J":
				classification = PersonClassification.Junior;
				break;
			case "O":
				classification = PersonClassification.Sophomore;
				break;
			case "F":
			default:
				classification = PersonClassification.Freshman;
				break;
		}
		StudentService.Current.Add(new Student { Name = context.Name, Classification = classification });
        Shell.Current.GoToAsync("//Instructor");
    }
}
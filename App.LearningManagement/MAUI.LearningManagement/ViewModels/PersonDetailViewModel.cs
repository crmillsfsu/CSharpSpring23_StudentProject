using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MAUI.LearningManagement.ViewModels
{
    public class PersonDetailViewModel : INotifyPropertyChanged
    {
        public string Name { get; set; }
        public string ClassificationString { get; set; }

        public int Id { get; set; }

        public PersonDetailViewModel(int id=0)
        {
            if(id > 0)
            {
                LoadById(id);
            }
        }

        public void LoadById(int id)
        {
            if(id == 0) { return; }
            var person = StudentService.Current.GetById(id) as Student;
            if(person != null)
            {
                Name = person.Name;
                Id = person.Id;
                ClassificationString = ClassToString(person.Classification);
            }
            
            NotifyPropertyChanged(nameof(Name));
            NotifyPropertyChanged(nameof(ClassificationString));

        }

        public void AddPerson()
        {
         
            if (Id <= 0)
            {
                StudentService.Current.Add(new Student { Name = Name, Classification = StringToClass(ClassificationString) });
            } else
            {
                var refToUpdate = StudentService.Current.GetById(Id) as Student;
                refToUpdate.Name = Name;
                refToUpdate.Classification = StringToClass(ClassificationString);
            }
            Shell.Current.GoToAsync("//Instructor");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private PersonClassification StringToClass(string s)
        {
            PersonClassification classification;
            switch (s)
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

            return classification;
        }

        private string ClassToString(PersonClassification pc)
        {
            var classificationString = string.Empty;
            switch (pc)
            {
                case PersonClassification.Senior:
                    classificationString = "S";
                    break;
                case PersonClassification.Junior:
                    classificationString = "J";
                    break;
                case PersonClassification.Sophomore:
                    classificationString = "O";
                    break;
                case PersonClassification.Freshman:
                default:
                    classificationString = "F";
                    break;
            }
            return classificationString;
        }
    }
}

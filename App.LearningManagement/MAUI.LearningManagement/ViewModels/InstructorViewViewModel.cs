using Library.LearningManagement.Models;
using Library.LearningManagement.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace MAUI.LearningManagement.ViewModels
{
    public class InstructorViewViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Person> People
        {
            get
            {
                return new ObservableCollection<Person>(StudentService.Current.Students);
            }
        }

        public Person SelectedPerson { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void AddClick(Shell s)
        {
            s.GoToAsync("//PersonDetail");
        }

        public void RemoveClick()
        {
            if(SelectedPerson == null) { return; }

            StudentService.Current.Remove(SelectedPerson);
            RefreshView();
        }

        public void RefreshView()
        {
            NotifyPropertyChanged(nameof(People));
        }

    }
}

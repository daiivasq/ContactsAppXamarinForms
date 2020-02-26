using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ContactsApp.ViewModels
{
    public class RegisterContactPageViewModel : INotifyPropertyChanged
    {
        public ICommand AddPhotoCommand { get; set; }

        public ICommand SaveContatcsCommand { get; set; }
        Person _AddPerson;
        public Person AddPerson
        {
            get
            {
                return _AddPerson;
            }
            set
            {
                _AddPerson = value;
                if (_AddPerson != null)
                    return;
            }
        }

        public RegisterContactPageViewModel(ObservableCollection<Person> contacts)
        {

            AddPerson = new Person() { ProfilePhoto = "profiledai.png" };
            SaveContatcsCommand = new Command(async () => {
                contacts.Add(AddPerson);
                await App.Current.MainPage.Navigation.PopAsync();

            });
        }
        public RegisterContactPageViewModel(ObservableCollection<Person> contacts, Person _contactsSelectec)
        {
            AddPerson = _contactsSelectec;
            SaveContatcsCommand = new Command(async  () => {
                contacts.Add(AddPerson);
                await App.Current.MainPage.Navigation.PopAsync();

            });
        }     
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

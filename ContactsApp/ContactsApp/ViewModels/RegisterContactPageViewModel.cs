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
        Person _addPerson;
        public Person AddPerson
        {
            get
            {
                return _addPerson;
            }
            set
            {
                _addPerson = value;
                if (_addPerson != null)
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
                contacts.Add(_contactsSelectec);
                await App.Current.MainPage.Navigation.PopAsync();

            });
        }     
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

using ContactsApp.Models;
using ContactsApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Essentials;


namespace ContactsApp.ViewModels
{
   public class ContactsPageViewModel : INotifyPropertyChanged
    {
        public ICommand DeleteSelectedCommand { get; set; }
        public ICommand EditSelectedCommand { get; set; }
        public ICommand AddContactCommand { get; set; }

        Person _ContactsSelectec;
        public Person ContactsSelected
        {
            get
            {
                return _ContactsSelectec;
            }
            set
            {
                _ContactsSelectec = value;
                if (_ContactsSelectec != null)
                    DisplayElementSelect();
               
            }
        }
        public ObservableCollection<Person> Contacts { get; set; } = new ObservableCollection<Person>();


        public ContactsPageViewModel(ObservableCollection<Person> contacts)
        {
            Contacts.Add(new Person() { Name = "RAFAEL", LastName = "CHICA MALA " , Phone = "809-664-1604", ProfilePhoto = "profiledai.png" }) ;
            Contacts.Add(new Person() { Name = "Dayanna", LastName = "Vasquez ", Phone = "809-664-0000", ProfilePhoto = "profiledai.png" });
 
            DeleteSelectedCommand = new Command<Person>(async(_ContactsSelectec) => {
                if (Contacts.Remove(_ContactsSelectec))
                {
                    await App.Current.MainPage.DisplayAlert("WARNING", "DELETE :" + _ContactsSelectec.Name  , "OK");
                }
                
        });
            EditSelectedCommand = new Command<Person>(async (_ContactsSelectec) => {
                await App.Current.MainPage.Navigation.PushAsync(new RegisterContactPage(Contacts, _ContactsSelectec));
            });
            AddContactCommand = new Command(async (_ContactsSelectec) => {

                await App.Current.MainPage.Navigation.PushAsync( new RegisterContactPage(Contacts));
            });

        }
        public async void DisplayElementSelect()
        {
            string Action;
            Action = await App.Current.MainPage.DisplayActionSheet("Choose ", "View information" ,"Call Contact");
            
            if (Action == "View information")
            {
                await App.Current.MainPage.DisplayAlert("Contacto seleccionado:", " Name :" + ContactsSelected.Name + "\nLAST NAME :" + ContactsSelected.LastName +  "\nphone.png" + ContactsSelected.Phone + "\nmail.png" + ContactsSelected.Email , "OK");
            }
            else if (Action == "Call Contact")
            {
                PlacePhoneCall(_ContactsSelectec.Phone);
            }
            else
            {
                return;
            }
        }
      
            public void PlacePhoneCall(string number)
            {
                try
                {
                    PhoneDialer.Open(number);
                }
                catch (ArgumentNullException anEx)
                {
                    // Number was null or white space
                }
                catch (FeatureNotSupportedException ex)
                {
                    // Phone Dialer is not supported on this device.
                }
                catch (Exception ex)
                {
                    // Other error has occurred.
                }
            }
       
        public event PropertyChangedEventHandler PropertyChanged;
    }
}

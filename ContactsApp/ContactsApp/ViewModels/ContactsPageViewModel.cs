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

        Person _contactsSelectec;
        public Person ContactsSelected
        {
            get
            {
                return _contactsSelectec;
            }
            set
            {
                _contactsSelectec = value;
                if (_contactsSelectec != null)
                    DisplayElementSelect();
            }
        }
        public ObservableCollection<Person> Contacts { get; set; } = new ObservableCollection<Person>();


        public ContactsPageViewModel(ObservableCollection<Person> contacts)
        {
            DeleteSelectedCommand = new Command<Person>(async(_contactsSelectec) => {
                if (Contacts.Remove(_contactsSelectec))
                await App.Current.MainPage.DisplayAlert("WARNING", $" Deleted Contact : \n Name: {_contactsSelectec.Name} \n Number : {_contactsSelectec.Phone} " , "OK");
              
                
        });
            EditSelectedCommand = new Command<Person>(async (_contactsSelectec) => {

                Contacts.Remove(_contactsSelectec);
                await App.Current.MainPage.Navigation.PushAsync(new RegisterContactPage(Contacts, _contactsSelectec));
                   
           
            });
            AddContactCommand = new Command(async (_ContactsSelectec) => {

                await App.Current.MainPage.Navigation.PushAsync( new RegisterContactPage(Contacts));
            });
        }
        public async void DisplayElementSelect()
        {
            string Action, Choose, ViewInformation, CallContact;
            Choose = "Chooae"; ViewInformation = "View Information"; CallContact = "Call Contact ";
            Action = await App.Current.MainPage.DisplayActionSheet($"{Choose}", $"{ViewInformation}", $"{CallContact}");

            if (Action == ViewInformation)
            {
                await App.Current.MainPage.DisplayAlert("selected contact", $"Name: {ContactsSelected.Name} \n Last Name : {ContactsSelected.LastName} \n Number : {ContactsSelected.Phone} \n Mail : {ContactsSelected.Email}", "OK");
            }
            else if (Action == CallContact)
            {
                PlacePhoneCall(_contactsSelectec.Phone);
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

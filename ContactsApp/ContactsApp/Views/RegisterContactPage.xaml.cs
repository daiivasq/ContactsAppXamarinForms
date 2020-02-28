using ContactsApp.Models;
using ContactsApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ContactsApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterContactPage : ContentPage
    {
     
        public RegisterContactPage(ObservableCollection<Person> people)
        {
            InitializeComponent();
            BindingContext = new RegisterContactPageViewModel(people);
            
        }

        public RegisterContactPage(ObservableCollection<Person> people, Person _contactsSelectec)
        {
            InitializeComponent();
            BindingContext = new RegisterContactPageViewModel(people, _contactsSelectec);
        }
  


   
    }
}
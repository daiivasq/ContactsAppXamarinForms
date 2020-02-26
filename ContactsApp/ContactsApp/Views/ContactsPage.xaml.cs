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
    public partial class ContactsPage : ContentPage
    {
        public ContactsPage(ObservableCollection<Person> contact)
        {
            InitializeComponent();
            BindingContext = new ContactsPageViewModel(contact);
        }

        public void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            string toLower = System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(e.NewTextValue);
            var ContainerSearch = BindingContext as ContactsPageViewModel;
            ListContacts.BeginRefresh();
            if (string.IsNullOrWhiteSpace(toLower))
            {
                ListContacts.ItemsSource = ContainerSearch.Contacts;
            }
            else
            {
                ListContacts.ItemsSource = ContainerSearch.Contacts.Where(s => s.Name.Contains(toLower));
            }
            ListContacts.EndRefresh();
            SearchBar searchBar = (SearchBar)sender;

        }

    }
}
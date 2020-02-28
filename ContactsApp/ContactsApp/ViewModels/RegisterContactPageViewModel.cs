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
        public List<TypePicker> Genders { get; set; }
        public List<TypePicker> PhoneType { get; set; }
        private TypePicker selectedGender;
        private TypePicker selectedPhone;

        public TypePicker SelectedGender
        {
            get { return selectedGender; }
            set
            {
                selectedGender = value;
                if (selectedGender != null)
                {
                    Gender();
                }

                
            }
               
        }
        public TypePicker SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                if (selectedPhone != null)
                {
                    TypePhone();
                }
            }
        }
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
            PickerGender();
            PickerPhone();
            AddPerson = new Person() { ProfilePhoto = "profiledai.png"};
          
            SaveContatcsCommand = new Command(async () => {
                if (AddPerson.Gender == "Female")
                {
                    AddPerson.ProfilePhoto = "UserGirl.png";
                }
                else if (AddPerson.Gender == "Male")
                {
                    AddPerson.ProfilePhoto = "UserBoy.png";
                }
                else
                {
                    AddPerson.ProfilePhoto = "usuario.png";
                }

                contacts.Add(AddPerson);
                await App.Current.MainPage.Navigation.PopAsync();

            });
        }
        public RegisterContactPageViewModel(ObservableCollection<Person> contacts, Person _contactsSelectec)
        {
            PickerGender();
            PickerPhone();
                        AddPerson = _contactsSelectec;
            SaveContatcsCommand = new Command(async  () => {
                if (AddPerson.Gender == "Female")
                {
                    AddPerson.ProfilePhoto = "UserGirl.png";
                }
                else if (AddPerson.Gender == "Male")
                {
                    AddPerson.ProfilePhoto = "UserBoy.png";
                }
                else
                {
                    AddPerson.ProfilePhoto = "usuario.png";
                }
                contacts.Add(_contactsSelectec);
                await App.Current.MainPage.Navigation.PopAsync();

            });
        }     

        public void PickerGender()
        {
            Genders = new List<TypePicker>() { };
            Genders.Add(new TypePicker { Gender = "Female" });
            Genders.Add(new TypePicker { Gender = "Male" });
        }
        public void PickerPhone()
        {
            PhoneType = new List<TypePicker>();
            PhoneType.Add(new TypePicker { Selected = "Mobile" });
            PhoneType.Add(new TypePicker { Selected = "Home" });
            PhoneType.Add(new TypePicker { Selected = "Main" });
            PhoneType.Add(new TypePicker { Selected = "Labor" });
            PhoneType.Add(new TypePicker { Selected = "Particular" });
        }
     
        public void Gender ()
        {
           AddPerson.Gender = SelectedGender.Gender;
        }
        public void TypePhone()
        {
            AddPerson.TypePhone = SelectedPhone.Selected;
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}

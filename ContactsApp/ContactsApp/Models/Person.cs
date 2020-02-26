using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ContactsApp.Models
{
    public class Person
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string ProfilePhoto { get; set; }
        public Color Color { get; set; }

    }
}

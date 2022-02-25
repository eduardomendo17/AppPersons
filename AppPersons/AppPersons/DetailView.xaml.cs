using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppPersons
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DetailView : ContentPage
    {
        MainPage Mainpage;
        PersonModel Person = new PersonModel();

        public DetailView(MainPage mainPage)
        {
            InitializeComponent();

            this.Mainpage = mainPage;
        }

        public DetailView(MainPage mainPage, PersonModel person)
        {
            InitializeComponent();

            this.Mainpage = mainPage;
        }

        private void ButtonSave_Clicked(object sender, EventArgs e)
        {
            if (this.Person.ID > 0)
            {
                // Actualizar
                for (int index = 0; index < this.Mainpage.Persons.Count; index++)
                {
                    if (this.Mainpage.Persons[index].ID == this.Person.ID)
                    {
                        this.Mainpage.Persons[index].Picture = EntryPicture.Text;
                        this.Mainpage.Persons[index].FirstName = EntryFirstName.Text;
                        this.Mainpage.Persons[index].LastName = EntryLastName.Text;
                        this.Mainpage.Persons[index].Age = int.Parse(EntryAge.Text);
                        this.Mainpage.Persons[index].Phone = EntryPhone.Text;
                        break;
                    }
                }
            }
            else
            {
                // Crear
                Person.Picture = EntryPicture.Text;
                Person.FirstName = EntryFirstName.Text;
                Person.LastName = EntryLastName.Text;
                Person.Age = int.Parse(EntryAge.Text);
                Person.Phone = EntryPhone.Text;

                // Agregamos la nueva persona a nuestro listado de personas
                this.Mainpage.Persons.Add(Person);
            }

            // Refrescamos nuestro collectionview
            this.Mainpage.ListRefresh();

            // Regresar a la vista del listado
            Navigation.PopAsync();
        }

        private void ButtonCancel_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}
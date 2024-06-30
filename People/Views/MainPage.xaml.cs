using People.Models;
using People.Repositorios;
using System.Collections.Generic;
using SQLite;

namespace People.Views
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        public void OnNewButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            PersonRepository person_repository = new PersonRepository("path");
            Person person = new Person
            {
                name = newPerson.Text
            };
            person_repository.AddNewPerson(person);
           
        }

        public void OnGetButtonClicked(object sender, EventArgs args)
        {
            statusMessage.Text = "";
            List<Person> people = App.PersonRepo.GetAllPeople();
            peopleList.ItemsSource = people;
        }
    }
}

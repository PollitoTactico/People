using System.Security.Cryptography.X509Certificates;
using People.Repositorios;
namespace People;

public partial class App : Application
{
    public static PersonRepository PersonRepo { get; set; }
    public App(PersonRepository repo)
        {
            InitializeComponent();
            MainPage = new AppShell();
            PersonRepo = repo;  
        }

    }


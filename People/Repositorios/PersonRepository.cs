
using People.Models;
using SQLite;

namespace People.Repositorios;

    public class PersonRepository
    {
        string _dbPath;

        public string StatusMessage { get; set; }
        private SQLiteConnection conn;

        private void Init()
        {
            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Person>();

        }
        public PersonRepository(string dbPath)
        {
            _dbPath = dbPath;

        }

       
        public void AddNewPerson(Person person)
        {
            try
            {
                Init();
                conn.Insert(person);
                StatusMessage = string.Format("{0} record(s) added [Name: {1})", person.name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", person.name, ex.Message);
                throw;
            }
        }

        public void UpdatePerson(Person person)
        {
            try
            {
               Init();
               conn.Update(person);
               
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public List<Person> GetAllPeople()
        {
            try
            {
                Init();
                return conn.Table<Person>().ToList().OrderBy(x=> x.name).ToList();
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new List<Person>();
        }
        public Person GetPerson(int id)
        {
            try
            {
                Init();
                var people = conn.Table<Person>().ToList();
                Person person = people.Find(p => p.id == id);
                return person;
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
            }
            return new Person();
        }
        public void DeletePerson(int id)
        {
            try
            {
                Init();
                conn.Delete<Person>(id);
                StatusMessage = string.Format("{0} record(s) deleted [Id: {1})", id);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to delete {0}. Error: {1}", id, ex.Message);
            }
        }
        public void AddNewPerson(string name)
        {
            int result = 0;
            try
            {

                if (string.IsNullOrEmpty(name))
                    throw new Exception("Valid name required");

                result = 0;

                StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, name);
            }
            catch (Exception ex)
            {
                StatusMessage = string.Format("Failed to add {0}. Error: {1}", name, ex.Message);
            }

        }

    }


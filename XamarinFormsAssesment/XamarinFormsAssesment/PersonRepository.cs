using XamarinFormsAssesment.Models;
using SQLite;

namespace XamarinFormsAssesment;

public class PersonRepository
{
    string _dbPath;

    public string StatusMessage { get; set; }

    // TODO: Add variable for the SQLite connection
    private SQLiteConnection conn;

    private void Init()
    {
        // TODO: Add code to initialize the repository
        if (conn != null)
            return;

        conn = new SQLiteConnection(_dbPath);
        conn.CreateTable<Person>();
    }

    public PersonRepository(string dbPath)
    {
        _dbPath = dbPath;
    }

    public void AddNewPerson(Person data)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()
            Init();

            // TODO: Insert the new person into the database
            result = conn.Insert(data);

            StatusMessage = string.Format("{0} record(s) added (Name: {1})", result, data.FirstName);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to add {0}. Error: {1}", data.FirstName, ex.Message);
        }

    }

    public List<string> GetAllPeople()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            Init();

            var result = new List<string>();

            foreach(var data in conn.Table<Person>().ToList())
                result.Add(String.Format("{0} {1}, {2}", data.FirstName, data.LastName, CalculateAge(data.DateOfBirth)));

            return result;
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<string>();
    }

    public List<Person> GetPeopleData()
    {
        // TODO: Init then retrieve a list of Person objects from the database into a list
        try
        {
            Init();

            return conn.Table<Person>().ToList();
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to retrieve data. {0}", ex.Message);
        }

        return new List<Person>();
    }

    public void DeletePerson(Person data)
    {
        int result = 0;
        try
        {
            // TODO: Call Init()
            Init();

            // TODO: Insert the new person into the database
            result = conn.Delete(data);

            StatusMessage = string.Format("{0} record(s) deleted (Name: {1})", result, data.FirstName);
        }
        catch (Exception ex)
        {
            StatusMessage = string.Format("Failed to delete {0}. Error: {1}", data.FirstName, ex.Message);
        }

    }

    private static int CalculateAge(DateTime birthDate)
    {
        var today = DateTime.Today;
        int age = today.Year - birthDate.Year;

        // Adjust if the birthday hasn't occurred yet this year
        if (birthDate.Date > today.AddYears(-age))
            age--;

        return age;
    }
}

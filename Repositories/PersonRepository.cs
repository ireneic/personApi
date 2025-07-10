using MySql.Data.MySqlClient;
using Person_Api.Repositories;

namespace Person_Api.Repository;

public class PersonRepository : IPersonRepository
{
    private readonly string  _configurationString;
    public PersonRepository(IConfiguration configuration)
    {
        _configurationString = configuration.GetConnectionString("Default");
    }

    public List<Person> GetPersons()
    {
        var persons = new List<Person>();
        
        using var conn = new MySqlConnection(_configurationString);
        conn.Open();
        
        var query = @"
    SELECT 
        p.id AS PersonId, 
        p.email, 
        pr.name, 
        pr.age, 
        pr.company 
    FROM Person p
    JOIN Profile pr ON p.profile_id = pr.id";
        using var cmd = new MySqlCommand(query, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            var person = new Person
            {
                Id = reader.GetInt32("Id"),
                Email = reader.GetString("Email"),
                Profile = new Profile
                {
                    Name = reader.GetString("Name"),
                    Age = reader.GetInt32("Age"),
                    Company = reader.GetString("Company")
                }
            };

            persons.Add(person);
        }

        return persons;
    } 

}
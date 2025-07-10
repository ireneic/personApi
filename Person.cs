namespace Person_Api;

public class Person
{
    public int Id { get; set; }
    public string Email { get; set; }
    public Company? Profile { get; set; }
}
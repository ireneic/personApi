namespace Person_Api;

public class Person
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;

    public Profile? Profile { get; set; }
}
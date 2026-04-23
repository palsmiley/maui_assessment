using SQLite;

namespace XamarinFormsAssesment.Models;

[Table("people")]
public class Person
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    [MaxLength(250), Unique]
    public string FirstName { get; set; }

    [MaxLength(250), Unique]
    public string LastName { get; set; }

    public DateTime DateOfBirth { get; set; }
}
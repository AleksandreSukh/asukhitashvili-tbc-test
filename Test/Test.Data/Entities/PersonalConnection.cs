namespace Test.Data.Entities;

public class PersonalConnection
{
    public int FromId { get; set; }
    public Person From { get; set; }
    public int ToId { get; set; }
    public Person To { get; set; }
    public int ConnectionTypeId { get; set; }
    public ConnectionType ConnectionType { get; set; }
}
namespace Test.Data.Entities;

public class PhoneNumber
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public Person Person { get; set; }
    public int TypeId { get; set; }
    public PhoneNumberType Type { get; set; }
    public string Number { get; set; }
}
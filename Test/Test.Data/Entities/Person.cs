
namespace Test.Data.Entities
{
    public class Person
    {
        public Person()
        {
            ConnectionsTo = new List<PersonalConnection>();
            ConnectionsFrom = new List<PersonalConnection>();
            PhoneNumbers = new List<PhoneNumber>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Gender { get; set; }
        public string IdNumber { get; set; }
        public DateTime? BirthDate { get; set; }
        public int? CityId { get; set; }
        public City City { get; set; }
        public string Picture { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
        public List<PersonalConnection> ConnectionsTo { get; set; }
        public List<PersonalConnection> ConnectionsFrom { get; set; }
    }
}

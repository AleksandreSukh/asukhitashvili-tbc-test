using Test.Data.Entities.Enums;

namespace Test.Data.Entities;

public class ConnectionType : EnumEntity
{
    public int ConnectedPersonId { get; set; }
    public PersonalConnection? ConnectedPerson { get; set; }
}
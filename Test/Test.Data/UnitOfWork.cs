using Test.Data.Entities;
using Test.Data.Infrastructure;

namespace Test.Data;

public sealed class UnitOfWork(TestDbContext context) : IDisposable
{
    private GenericRepository<City>? _cityRepository;
    private GenericRepository<ConnectionType>? _connectionTypeRepository;
    private GenericRepository<Person>? _personRepository;
    private GenericRepository<PersonalConnection>? _personalConnectionRepository;
    private GenericRepository<PhoneNumber>? _phoneNumberRepository;
    private GenericRepository<PhoneNumberType>? _phoneNumberTypeRepository;

    private bool _disposed;

    public GenericRepository<City> CityRepository => _cityRepository ??= new(context);
    public GenericRepository<ConnectionType> ConnectionTypeRepository => _connectionTypeRepository ??= new(context);
    public GenericRepository<Person> PersonRepository => _personRepository ??= new(context);
    public GenericRepository<PersonalConnection> PersonalConnectionRepository => _personalConnectionRepository ??= new(context);
    public GenericRepository<PhoneNumber> PhoneNumbeRepository => _phoneNumberRepository ??= new(context);
    public GenericRepository<PhoneNumberType> PhoneNumberTypeRepository => _phoneNumberTypeRepository ??= new(context);

    public void Save() => context.SaveChanges();

    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            context.Dispose();
        }
        _disposed = true;
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
}
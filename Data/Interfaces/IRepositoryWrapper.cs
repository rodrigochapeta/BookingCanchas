  
namespace Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGameRepository Games { get; }
        IBusinessRepository Businesses { get; }
        IFieldRepository Fields { get; }
        ICustomerRepository Customers { get; }
        IBookingRepository Bookings { get; }
    }
}

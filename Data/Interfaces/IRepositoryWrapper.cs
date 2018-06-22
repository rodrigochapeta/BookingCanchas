  
namespace Data.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGameRepository Game { get; }
        IBusinessRepository Business { get; }
        IFieldRepository Field { get; }
        ICustomerRepository Customer { get; }
        IBookingRepository Booking { get; }
    }
}

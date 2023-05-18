using TestOrionTek.Data.Interface;

namespace TestOrionTek.Data.GenericRepository
{
    public interface IRepositoryWrapper
    {
        ICompanyRepository Company { get; }
        ICustomerDetailsRepository CustomerDetails { get; }
        ICustomerRepository Customer { get; }
        void Save();
    }
}

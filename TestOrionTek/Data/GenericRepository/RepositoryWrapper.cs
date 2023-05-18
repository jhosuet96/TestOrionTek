using TestOrionTek.Data.Interface;
using TestOrionTek.Data.Repository;

namespace TestOrionTek.Data.GenericRepository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {

        private TestOrionTek_apiContext _ApiContext;
        private ICompanyRepository? _company;
        private ICustomerDetailsRepository? _customerDetails;
        private ICustomerRepository? _customer;

        public RepositoryWrapper(TestOrionTek_apiContext ApiContext)
        {
            _ApiContext = ApiContext;
        }

        public ICompanyRepository Company
        {
            get
            {
                if (_company == null)
                {
                    _company = new CompanyRepository(_ApiContext);
                }
                return _company;
            }
        }

        public ICustomerDetailsRepository CustomerDetails
        {
            get
            {
                if (_customerDetails == null)
                {
                    _customerDetails = new CustomerDetailsRepository(_ApiContext);
                }
                return _customerDetails;
            }
        }

        public ICustomerRepository Customer
        {
            get
            {
                if (_customer == null)
                {
                    _customer = new CustomerRepository(_ApiContext);
                }
                return _customer;
            }
        }

        public void Save()
        {
            _ApiContext.SaveChanges();
        }
    }
}

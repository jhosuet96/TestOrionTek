using TestOrionTek.Data.GenericRepository;
using TestOrionTek.Data.Models;

namespace TestOrionTek.Service
{
    public class Utility
    {
        private IQueryable<Customer> _customers;
        private readonly IRepositoryWrapper _repo;
        public Utility(IRepositoryWrapper repo)
        {
            _repo = repo ?? throw new ArgumentNullException(nameof(repo));
        }

        public IQueryable<Customer> getAllCustomers()
        {
            try
            {
                _customers = _repo.Customer.GetAll().Where(x => x.status == true).Select(c => new Customer
                {
                    IdCustomer = c.IdCustomer,
                    Name = c.Name,
                    LastName = c.LastName,
                    status = c.status,
                    IdCompany = c.IdCompany,
                    CustomerDetails = c.CustomerDetails
                });
                return _customers;
            }
            catch (Exception)
            {
                throw;
            }           
        }

        public Customer GetById(int id)
        {
            Customer customer = new Customer();
            List<CustomerDetails> customerDetails = new List<CustomerDetails>();
            try
            {
                customer = _repo.Customer.GetById(id);
                if (customer != null)
                {              
                    customerDetails = _repo.CustomerDetails.FindByCondition(cd => cd.IdCustomer == customer.IdCustomer).ToList();
                    if (customerDetails.Count>0)
                    {
                        foreach (var item in customerDetails)
                        {
                            customer.CustomerDetails.Add(item);
                        }
                    }
                    return customer;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public IQueryable<Company> getAllCompany()
        {
            try
            {
                var company = _repo.Company.GetAll().Where(x => x.status == true).Select(c => new Company
                {
                    IdCompany = c.IdCompany,
                    NameCompany = c.NameCompany,
                    status = c.status,
                    Customers = c.Customers
                }).OrderBy(x => x.NameCompany);
                return company;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}

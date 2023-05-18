using TestOrionTek.Data.Interface;
using TestOrionTek.Data.Models;

namespace TestOrionTek.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(TestOrionTek_apiContext ApiContext) : base(ApiContext)
        {

        }
    }
}

using TestOrionTek.Data.Interface;
using TestOrionTek.Data.Models;
namespace TestOrionTek.Data.Repository
{
    public class CustomerDetailsRepository : Repository<CustomerDetails> ,ICustomerDetailsRepository 
    {
        public CustomerDetailsRepository(TestOrionTek_apiContext ApiContext) : base(ApiContext)
        {

        }
    }
}

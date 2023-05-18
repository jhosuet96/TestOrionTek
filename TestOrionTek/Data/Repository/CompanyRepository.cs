using TestOrionTek.Data.Interface;
using TestOrionTek.Data.Models;

namespace TestOrionTek.Data.Repository
{
    public class CompanyRepository : Repository<Company>, ICompanyRepository
    {
        public CompanyRepository(TestOrionTek_apiContext ApiContext) : base(ApiContext)
        {

        }
    }
}

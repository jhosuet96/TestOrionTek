using System.ComponentModel.DataAnnotations;
using TestOrionTek.Data.Dtos.CustomerDetailsDto;

namespace TestOrionTek.Data.Dtos.CustomersDto
{
    public class CustomersUpdateDto
    {
        [Required]
        public int IdCustomer { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public bool status { get; set; }
        public int IdCompany { get; set; }

    }
}

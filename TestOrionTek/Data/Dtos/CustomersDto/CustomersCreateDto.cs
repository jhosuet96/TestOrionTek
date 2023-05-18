using System.ComponentModel.DataAnnotations;
using TestOrionTek.Data.Dtos.CustomerDetailsDto;

namespace TestOrionTek.Data.Dtos.CustomersDto
{
    public class CustomersCreateDto
    {
        public int IdCustomer { get; set; }

        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public bool status { get; set; }
        [Required]
        public int IdCompany { get; set; }

        public ICollection<CustomerDetailsCreateDto> CustomerDetails { get; set; }
    }
}

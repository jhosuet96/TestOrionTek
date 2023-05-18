using System.ComponentModel.DataAnnotations;

namespace TestOrionTek.Data.Dtos.CustomerDetailsDto
{
    public class CustomerDetailsCreateDto
    {

        [Required]
        public int IdCustomerDetail { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        [Required]
        public string? Address { get; set; }
       
        public string? Email { get; set; }
        [Required]
        public bool status { get; set; }
    }
}

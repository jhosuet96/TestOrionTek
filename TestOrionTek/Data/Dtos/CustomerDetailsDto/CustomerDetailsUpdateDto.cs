using System.ComponentModel.DataAnnotations;

namespace TestOrionTek.Data.Dtos.CustomerDetailsDto
{
    public class CustomerDetailsUpdateDto
    {

        [Required]
        public int IdCustomerDetail { get; set; }
        [Required]
        public int IdCustomer { get; set; }
        public string? Address { get; set; }
       
        public string? Email { get; set; }
        public bool status { get; set; }
    }
}

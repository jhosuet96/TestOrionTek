using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestOrionTek.Data.Models
{
    public class CustomerDetails
    {
     
        [Key]
        public int IdCustomerDetail { get; set; }

       
        public int IdCustomer { get; set; }
        
        [ForeignKey(nameof(IdCustomer))]
        public virtual Customer? Customers { get; set; }

        [Required]
        public string? Address { get; set; }
        public string? Email { get; set; }
        public bool status { get; set; }
    }
}

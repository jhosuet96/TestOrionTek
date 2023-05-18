using System.ComponentModel.DataAnnotations;

namespace TestOrionTek.Data.Models
{
    public class Company
    {
        public Company()
        {
            Customers = new HashSet<Customer>();
        }
        [Key]
        public int IdCompany { get; set; }

        [Required]
        public string NameCompany { get; set; }
        public bool status { get; set; }

        public virtual ICollection<Customer> Customers { get; set; }
    }
}

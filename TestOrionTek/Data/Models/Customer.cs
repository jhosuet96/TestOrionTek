using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TestOrionTek.Data.Models
{
    public class Customer
    {
      
        [Key]
        public int IdCustomer { get; set; }
      
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? LastName { get; set; }
        public bool status { get; set; }
        public int IdCompany { get; set; }

        [JsonIgnore]
        [ForeignKey(nameof(IdCompany))]
        public virtual Company? Company { get; set; }
        public virtual ICollection<CustomerDetails>? CustomerDetails { get; set; }
    }
}

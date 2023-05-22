using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using TestOrionTek.Data.Dtos.CustomerDetailsDto;

namespace TestOrionTek.Data.Dtos.CustomersDto
{
    public class CustomersUpdateDto
    {
        [Required]
        public int IdCustomer { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        [JsonIgnore]
        public bool status { get; set; } = true;
        public int IdCompany { get; set; }

    }
}

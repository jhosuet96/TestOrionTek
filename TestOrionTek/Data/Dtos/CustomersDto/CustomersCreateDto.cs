using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
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
        [JsonIgnore]
        public bool status { get; set; } = true;
        [Required]
        public int IdCompany { get; set; }

    }
}

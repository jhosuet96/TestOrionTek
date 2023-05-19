using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TestOrionTek.Data.Dtos.CompanyDto
{
    public class CompanyCreateDto
    {
       
        [Required]
        public string? NameCompany { get; set; }

        [JsonIgnore]
        public bool status { get; set; } = true;
    }
}

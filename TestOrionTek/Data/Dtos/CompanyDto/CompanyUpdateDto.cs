using System.ComponentModel.DataAnnotations;

namespace TestOrionTek.Data.Dtos.CompanyDto
{
    public class CompanyUpdateDto
    {
        [Required]
        public int IdCompany { get; set; }
        [Required]
        public string? NameCompany { get; set; }
        public bool status { get; set; }
    }
}

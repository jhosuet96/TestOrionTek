using System.ComponentModel.DataAnnotations;

namespace TestOrionTek.Data.Dtos.CompanyDto
{
    public class CompanyCreateDto
    {
        [Required]
        public int IdCompany { get; set; }
        [Required]
        public string? NameCompany { get; set; }
        public bool status { get; set; }
    }
}

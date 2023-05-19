using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestOrionTek.Data.Dtos.CompanyDto;
using TestOrionTek.Data.GenericRepository;
using TestOrionTek.Data.Models;
using TestOrionTek.Service;

namespace TestOrionTek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompanyController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper mapper;
        private Utility utility;
        public CompanyController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
            utility = new Utility(repository);

        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var company = utility.getAllCompany();
            return Ok(company);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id > 0)
            {
                var company = _repository.Company.GetById(id);
                return Ok(company);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AddCompany")]
        public IActionResult AddCompany([FromBody] CompanyCreateDto companyDto)
        {
            if (companyDto == null)
            {
                return NotFound();
            }
            try
            {
                var custDto = mapper.Map<Company>(companyDto);
                _repository.Company.Add(custDto);
                _repository.Save();
                return Ok(new
                {
                    message = "Registro creado EXITOSAMENTE.!"
                });
            }
            catch (Exception)
            {

                return NotFound();
            }
        }

        [HttpPatch]
        [Route("UpdateCompany")]
        public IActionResult UpdateCompany(CompanyUpdateDto customer)
        {
            try
            {
                if (customer != null)
                {
                    var custDto = mapper.Map<Company>(customer);
                    _repository.Company.Update(custDto);
                    _repository.Save();
                    return Ok(custDto);
                }
                return NotFound();
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("DeleteCompany/{id:int}")]
        public IActionResult DeleteCompany(int id)
        {
            if (id > 0)
            {
                var company = _repository.Company.GetById(id);
                if (company.status == true)
                {
                    company.status = false;
                }
                _repository.Company.Update(company);
                _repository.Save();
                return Ok(company);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}

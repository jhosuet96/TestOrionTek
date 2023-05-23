using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TestOrionTek.Data.Dtos.CustomerDetailsDto;
using TestOrionTek.Data.GenericRepository;
using TestOrionTek.Data.Models;
using TestOrionTek.Service;

namespace TestOrionTek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerDetailsController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper mapper;
        public CustomerDetailsController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;
            this.mapper = mapper;
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var customerDetails = _repository.CustomerDetails.GetAll().Where(x => x.status == true).OrderBy(x => x.Customers.Name);
            return Ok(customerDetails);
        }

        [HttpGet("GetByIdList")]
        public IActionResult GetByIdList([FromQuery] int id)
        {
            if (id > 0)
            {
                var customer = _repository.CustomerDetails.FindByCondition(x => x.IdCustomer == id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id > 0)
            {
                var customer = _repository.CustomerDetails.GetById(id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AddCustomerDetails")]
        public IActionResult AddCustomerDetails([FromBody] CustomerDetailsCreateDto customerDto)
        {
            if (customerDto == null)
            {
                return NotFound();
            }
            try
            {
                var custDto = mapper.Map<CustomerDetails>(customerDto);
                _repository.CustomerDetails.Add(custDto);
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
        [Route("UpdateCustomerDetails")]
        public IActionResult UpdateCustomerDetails(CustomerDetailsUpdateDto customer)
        {
            try
            {
                if (customer != null)
                {
                    var custDto = mapper.Map<CustomerDetails>(customer);
                    _repository.CustomerDetails.Update(custDto);
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
        [Route("DeleteCustomerDetails/{id:int}")]
        public IActionResult DeleteCustomerDetails(int id)
        {
            if (id > 0)
            {
                var customer = _repository.CustomerDetails.GetById(id);
                if (customer.status == true)
                {
                    customer.status = false;
                }
                _repository.CustomerDetails.Update(customer);
                _repository.Save();
                return Ok(customer);
            }
            else
            {
                return NotFound(id);
            }
        }
    }
}

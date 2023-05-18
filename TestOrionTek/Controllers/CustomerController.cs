using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TestOrionTek.Data.Dtos.CustomersDto;
using TestOrionTek.Data.GenericRepository;
using TestOrionTek.Data.Models;
using TestOrionTek.Service;

namespace TestOrionTek.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : Controller
    {
        private readonly IRepositoryWrapper _repository;
        private readonly IMapper mapper;

        private Utility utility;
        private Customer _customer;
        public CustomerController(IRepositoryWrapper repository)
        {
            _repository = repository;  
            _customer = new Customer();
            utility = new Utility(repository);
        }

        [HttpGet("GetAll")]
       // [EnableCors("AllowOrigin")]
        public IActionResult GetAll()
        { 
            var customer = utility.getAllCustomers();
            return Ok(customer);
        }

        [HttpGet("GetById")]
        public IActionResult GetById([FromQuery] int id)
        {
            if (id>0)
            {
                var customer = utility.GetById(id);
                return Ok(customer);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost("AddCustomer")]
       // [EnableCors("AllowOrigin")]
        public IActionResult AddCustomer([FromBody] CustomersCreateDto customerDto)
        {
            if (customerDto == null)
            {
                return NotFound();
            }
            try
            {   
                _customer.Name = customerDto.Name;
                _customer.LastName = customerDto.LastName;
                _customer.IdCompany = customerDto.IdCompany;
                _customer.status = customerDto.status;


                _repository.Customer.Add(_customer);
                _repository.Save();
                if (customerDto.CustomerDetails.Count >0)
                {
                    CustomerDetails customerDetails = new CustomerDetails();

                    foreach (var item in customerDto.CustomerDetails)
                    {
                        customerDetails.IdCustomer = _customer.IdCustomer;
                        customerDetails.Address = item.Address;
                        customerDetails.Email = item.Email;
                        customerDetails.IdCustomerDetail = 0;

                        _repository.CustomerDetails.Add(customerDetails);
                        _repository.Save();
                    }
                }                
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
        [Route("UpdateCustomer")]
        //[EnableCors("AllowOrigin")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            try
            {
                var customers = _repository.Customer.FindByCondition(c => c.IdCustomer == customer.IdCustomer).FirstOrDefault();
                if (customers != null)
                {
                    _repository.Customer.Update(customers);
                    _repository.Save();
                }

                if (customer.CustomerDetails.Count >= 1)
                {
                    foreach (var item in customer.CustomerDetails)
                    {
                        var customerDetails = _repository.CustomerDetails.FindByCondition(cd => cd.IdCustomerDetail == item.IdCustomerDetail).FirstOrDefault();
                        if(customerDetails != null)
                        {
                            _repository.CustomerDetails.Update(customerDetails);
                            _repository.Save();
                        }
                    }
                }
                return Ok(customers);
            }
            catch (Exception)
            {
                return NotFound();
            }
        }


        [HttpDelete]
        [Route("DeleteCustomer/{id:int}")]
      //  [EnableCors("AllowOrigin")]
        public IActionResult DeleteCustomer(int id)
        {
            if (id > 0)
            {
                var customer = _repository.Customer.GetById(id);
                if (customer.status ==false )
                {
                    customer.status =true ;
                }
                _repository.Customer.Update(customer);
                foreach (var item in customer.CustomerDetails)
                {
                    var customerDetails = _repository.CustomerDetails.FindByCondition(cd => cd.IdCustomerDetail == item.IdCustomerDetail).FirstOrDefault();
                    if (customerDetails != null)
                    {
                        customerDetails.status = true;
                        _repository.CustomerDetails.Update(customerDetails);
                        _repository.Save();
                    }
                }
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

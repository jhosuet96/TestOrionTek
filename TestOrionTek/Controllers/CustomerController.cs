﻿using AutoMapper;
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
        public CustomerController(IRepositoryWrapper repository, IMapper mapper)
        {
            _repository = repository;  
            this.mapper = mapper;
            utility = new Utility(repository);
        }

        [HttpGet("GetAll")]
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
        public IActionResult AddCustomer([FromBody] CustomersCreateDto customerDto)
        {
            if (customerDto == null)
            {
                return NotFound();
            }
            try
            {   
                var custDto = mapper.Map<Customer>(customerDto);
                _repository.Customer.Add(custDto);
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
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomersUpdateDto customer)
        {
            try
            {
                if (customer != null)
                {
                    var custDto = mapper.Map<Customer>(customer);
                    _repository.Customer.Update(custDto);
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
        [Route("DeleteCustomer/{id:int}")]
        public IActionResult DeleteCustomer(int id)
        {
            if (id > 0)
            {
                var customer = _repository.Customer.GetById(id);
                if (customer.status == true)
                {
                    customer.status =false ;
                }
                _repository.Customer.Update(customer);
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

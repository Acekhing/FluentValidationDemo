using AutoMapper;
using FluentValidationDemo.Data;
using FluentValidationDemo.DTO;
using FluentValidationDemo.Models;
using FluentValidationDemo.validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public class CustomerController: ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ApplicationContext dbContext;

        public CustomerController(IMapper mapper, ApplicationContext applicationContext)
        {
            _mapper = mapper;
            this.dbContext = applicationContext;
        }

        [HttpPost, ActionName("CreateCustomer")]
        [Route("")]
        public async Task<ActionResult> Create([FromBody] CustomerDto payload)
        {
            // Validate payload

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Map payload to entity
            var customerEntity = _mapper.Map<Customer>(payload);

           // TODO: validate Entity


            // TODO: Add customer to the database
            var result = await dbContext.AddAsync<Customer>(customerEntity);

            return Accepted(result);
        }

        [HttpGet(), ActionName("GetCustomer")]
        [Route("{customerId}")]
        public async Task<ActionResult> Get([FromRoute] Guid customerId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await dbContext.Customers.FindAsync(customerId);

            if(result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPut, ActionName("UpdateCustomer")]
        [Route("{customerId}")]
        public async Task<ActionResult> Update([FromRoute] Guid customerId, [FromBody] CustomerDto payload)
        {
            // Validate payload

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCustomer = await dbContext.Customers.FindAsync(customerId);

            if(existingCustomer == null)
            {
                return NotFound();
            }

            var customerEntity = _mapper.Map<Customer>(payload);
            //dbContext.Update<Customer>(payload);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet, ActionName("GetAllCustomers")]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await dbContext.Customers.ToListAsync();
            
            return Ok(result);
        }

        [HttpDelete(), ActionName("DeleteCustomer")]
        [Route("{customerId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid customerId)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await dbContext.Customers.FindAsync(customerId);

            if(result == null)
            {
                return NotFound(customerId);
            }

            dbContext.Remove(result);
            await dbContext.SaveChangesAsync();

            return NoContent();
        }
    }


}

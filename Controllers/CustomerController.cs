using AutoMapper;
using FluentValidationDemo.DTO;
using FluentValidationDemo.InterfaceRepositories;
using FluentValidationDemo.Response;
using Microsoft.AspNetCore.Mvc;

namespace FluentValidationDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerRepository repository;

        public CustomerController(ICustomerRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost, ActionName("CreateCustomer")]
        [Route("")]
        public async Task<ActionResult> Create([FromBody] CustomerCreateDto payload)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = await repository.Create(payload);

            if (response is FailureResponse)
            {
                var validationResult = ((FailureResponse)response).GetData();
                foreach (var error in validationResult.Errors)
                {
                    ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return ValidationProblem(ModelState);
            }
            var Id = ((SuccessReponse)response).GetData();

            return CreatedAtAction("GetCustomer", new { customerId = Id }, Id);
        }

        [HttpPut, ActionName("UpdateCustomer")]
        [Route("")]
        public async Task<ActionResult> Update([FromBody] CustomerUpdateDto payload)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var existingCustomer = await repository.Get(payload.CustomerId);

            if (existingCustomer == null) return NotFound();

            await repository.Update(payload);

            return Accepted();
        }

        [HttpGet(), ActionName("GetCustomer")]
        [Route("{customerId}")]
        public async Task<ActionResult> Get([FromRoute] Guid customerId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await repository.Get(customerId);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpGet, ActionName("GetAllCustomers")]
        [Route("")]
        public async Task<ActionResult> GetAll()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await repository.GetAll();

            return Ok(result);
        }

        [HttpDelete(), ActionName("DeleteCustomer")]
        [Route("{customerId}")]
        public async Task<ActionResult> Delete([FromRoute] Guid customerId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await repository.Get(customerId);

            if (result == null) return NotFound(customerId);

            await repository.Delete(customerId);

            return NoContent();
        }
    }


}

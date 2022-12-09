using Domain.Contracts.UseCases.AddCustomer;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Error;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCases;
        private readonly IValidator<AddCustomerInput> _addCustomerInputValidator;


        public AddCustomerController(IAddCustomerUseCase addCustomerUseCase, IValidator<AddCustomerInput> addCustomerInputValidator)
        {
            _addCustomerUseCases = addCustomerUseCase;
            _addCustomerInputValidator = addCustomerInputValidator;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            var validationResult = _addCustomerInputValidator.Validate(input);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.ToCustomValidationFailure());
            }
            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);
            _addCustomerUseCases.AddCustomer(customer);
            return Created("", customer);
        }
    }
}
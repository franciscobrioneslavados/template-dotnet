using Domain.Contracts.UseCases.AddCustomer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Customers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddCustomerController : ControllerBase
    {
        private readonly IAddCustomerUseCase _addCustomerUseCases;


        public AddCustomerController(IAddCustomerUseCase addCustomerUseCases)
        {
            _addCustomerUseCases = addCustomerUseCases;
        }

        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input)
        {
            var customer = new Domain.Entities.Customer(input.Name, input.Email, input.Document);
            _addCustomerUseCases.AddCustomer(customer);
            return Created("", customer);
        }
    }
}
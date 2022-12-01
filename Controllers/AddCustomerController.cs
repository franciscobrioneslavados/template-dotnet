using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]

    public class AddCustomerController: ControllerBase {
        [HttpPost]
        public IActionResult AddCustomer(AddCustomerInput input){
            
        }
    }
}
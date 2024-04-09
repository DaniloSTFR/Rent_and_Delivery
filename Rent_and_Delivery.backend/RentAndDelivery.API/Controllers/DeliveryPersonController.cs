using Microsoft.AspNetCore.Mvc;
using MediatR;
using RentAndDelivery.Application.Handlers.DeliveryPersonHandlers.Queries;

namespace RentAndDelivery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DeliveryPersonController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DeliveryPersonController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetDeliveryPersons")]
        public async Task<IActionResult> GetDeliveryPersons()
        {
            var query = new GetDeliveryPersonsQuery();
            var deliveryPersons = await _mediator.Send(query);
            return deliveryPersons != null ? Ok(deliveryPersons) : NotFound("DeliveryPersons not found!");
        }
        
    }
}
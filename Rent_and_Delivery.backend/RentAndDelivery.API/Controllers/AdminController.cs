using Microsoft.AspNetCore.Mvc;
using MediatR;
using RentAndDelivery.Application.Handlers.AdminHandlers.Queries;
using RentAndDelivery.Application.Handlers.AdminHandlers.Commands;

namespace RentAndDelivery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdminController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /*=[HttpGet("Id/{id}")]
        public async Task<IActionResult> GetAdminById(string id)
        {
            var query = new GetAdminByIdQuery{ Id = id };
            var admin = await _mediator.Send(query);
            return admin != null ? Ok(admin) : NotFound("Admin not found!");
        } */

        /*[HttpGet("GetAdmins")]
        public async Task<IActionResult> GetAdmins()
        {
            var query = new GetAdminsQuery();
            var admins = await _mediator.Send(query);
            return admins != null ? Ok(admins) : NotFound("Admins not found!");
        }&*/

        [HttpGet("FindByName/{name}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAdminByName(string name)
        {
            var query = new GetAdminByNameQuery{ Name = name };
            var admin = await _mediator.Send(query);
            return admin != null ? Ok(admin) : NotFound("Admin not found!");
        }

        [HttpPost("CreateAdmin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CreateAdmin(CreateAdminCommand command)
        {
            if(command == null)
            {
                return BadRequest("Invalid data!");
            }

            var createdAdmin = await _mediator.Send(command);
            return  createdAdmin!=null ? Ok(createdAdmin) : StatusCode(500,createdAdmin);
            //return CreatedAtAction(nameof(GetAdminByAdmin), new { id = createdAdmin.Id }, createdAdmin);
        }

        [HttpPost("RegisterMotorcycle")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> RegisterMotorcycle(RegisterMotorcycleCommand command)
        {
            if(command == null)
            {
                return BadRequest("Invalid data!");
            }

            var createdMotorcycle = await _mediator.Send(command);
            return  createdMotorcycle!=null ? Ok(createdMotorcycle) : StatusCode(500,createdMotorcycle);
            //return CreatedAtAction(nameof(GetAdminByAdmin), new { id = createdAdmin.Id }, createdAdmin);
        }

        [HttpGet("GetMotorcycleFilterByPlate/{plate}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetMotorcycleFilterByPlate(string plate)
        {
            var query = new GetMotorcycleFilterByPlateQuery{ Plate = plate };
            var motorcycles = await _mediator.Send(query);
            return motorcycles != null ? Ok(motorcycles) : NotFound("Admin not found!");
        }

        [HttpPut("UpdateMotorcyclePlate/{motorcycleId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> UpdateMotorcyclePlate(string motorcycleId, string plate)
        {
            var query = new UpdateMotorcyclePlateCommand{Id = motorcycleId, Plate = plate };
            var motorcycles = await _mediator.Send(query);
            return motorcycles != null ? Ok(motorcycles) : NotFound("Motorcycle not found!");
        }

        [HttpDelete("DeleteMotorcycleById/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteMember(string id)
        {
            var command = new DeleteMotorcycleCommand { Id = id };
            var deletedMotorcycle = await _mediator.Send(command);

            return deletedMotorcycle != null ? Ok(deletedMotorcycle) : NotFound("Motorcycle not deleted!");
        }

    }
}
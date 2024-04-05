using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RentAndDelivery.Domain.Interfaces;
using RentAndDelivery.Domain.Interfaces.Output;

namespace RentAndDelivery.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public AdminController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var admin = await _unitOfWork.AdminOutputRepository.GetAdminById(id);
            if (admin == null){
                return NotFound();
            }
             return admin != null ? Ok(admin) : NotFound("No admins!");
        }

        [HttpGet]
        public async Task<IActionResult> GetAdmins()
        {
            var admins = await _unitOfWork.AdminOutputRepository.GetAdmins();
            return admins != null ? Ok(admins) : NotFound("No admins!");
        }

    }
}
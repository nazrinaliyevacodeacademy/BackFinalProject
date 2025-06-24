using Final.Application.Features.Queries.Medicines.GetMedicineById;
using Final.Domain.Entities;
using Final.Persistence.Contexts;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicinesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly FinalDbContext _context;
        public MedicinesController(IMediator mediator, FinalDbContext context)
        {
            _mediator = mediator;
            _context = context;
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery]GetMedicineByIdQueryRequest request)
        {
            Medicine medicine = new()
            {
                Name = "Celebrix",
                Dosage = "100 ",
                Category="Medicine",
                Price = 30,
            };
            _context.Medicines.Add(medicine);
            _context.SaveChanges();
            return Ok();
           /* GetMedicineByIdQueryResponse response = await _mediator.Send(request);
            return Ok(response);*/
        }
    }
}

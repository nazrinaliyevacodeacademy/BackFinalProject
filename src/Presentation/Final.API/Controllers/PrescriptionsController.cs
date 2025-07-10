using Final.Application.DTOs.Prescription;
using Final.Application.Features.Commands.Prescriptions.CreatePrescription;
using Final.Application.Features.Commands.Prescriptions.DeletePrescription;
using Final.Application.Features.Commands.Prescriptions.UpdatePrescription;
using Final.Application.Features.Queries.Prescriptions.GetAllPrescriptions;
using Final.Application.Features.Queries.Prescriptions.GetPrescriptionById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Final.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PrescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Create([FromBody] CreatePrescriptionDTO dto)
        {
            var request = new CreatePrescriptionCommandRequest { Dto = dto };
            await _mediator.Send(request);
            return StatusCode(201);
        }

        [HttpGet]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllPrescriptionsQueryRequest());
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result = await _mediator.Send(new GetPrescriptionByIdQueryRequest { Id = id });
            if (result == null) return NotFound();
            return Ok(result);
        }

        [HttpPut]
        [Authorize(Roles = "Doctor")]
        public async Task<IActionResult> Update([FromBody] UpdatePrescriptionDTO dto)
        {
            var result = await _mediator.Send(new UpdatePrescriptionCommandRequest { Dto = dto });
            return result ? NoContent() : NotFound();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Doctor,Admin")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _mediator.Send(new DeletePrescriptionCommandRequest { Id = id });
            return result ? NoContent() : NotFound();
        }
       
    }
}



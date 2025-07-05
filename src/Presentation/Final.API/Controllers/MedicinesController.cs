using Final.Application.DTOs.Medicine;
using Final.Application.Features.Commands.Medicines.CreateMedicine;
using Final.Application.Features.Commands.Medicines.DeleteMedicine;
using Final.Application.Features.Commands.Medicines.UpdateMedicine;
using Final.Application.Features.Queries.Medicines.GetAllMedicines;
using Final.Application.Features.Queries.Medicines.GetMedicineById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : ControllerBase
{
    private readonly IMediator _mediator;

    public MedicinesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromForm] MedicinePostDTO dto)
    {
        var command = new CreateMedicineCommandRequest { Dto = dto };
        await _mediator.Send(command);
        return Ok(new { message = "Medicine created successfully." });
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromForm] MedicinePostDTO dto)
    {
        var command = new UpdateMedicineCommandRequest { Id = id, Dto = dto };
        await _mediator.Send(command);
        return Ok(new { message = "Medicine updated successfully." });
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteMedicineCommandRequest { Id = id };
        await _mediator.Send(command);
        return Ok(new { message = "Medicine deleted successfully." });
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var query = new GetMedicineByIdQueryRequest { Id = id };
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var query = new GetAllMedicinesQueryRequest();
        var result = await _mediator.Send(query);
        return Ok(result);
    }
}

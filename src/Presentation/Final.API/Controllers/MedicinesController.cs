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
             return Ok(response);


        


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
     public async Task<IActionResult> Create([FromBody] CreateMedicineCommandRequest request)
     {
         var id = await _mediator.Send(request);
         return CreatedAtAction(nameof(GetById), new { id }, null);
     }

     [HttpPut("{id}")]
     public async Task<IActionResult> Update(Guid id, [FromBody] MedicinePostDTO dto)
     {
         var request = new UpdateMedicineCommandRequest { Id = id, MedicinePostDTO = dto };
         await _mediator.Send(request);
         return NoContent();
     }

     [HttpDelete("{id}")]
     public async Task<IActionResult> Delete(Guid id)
     {
         await _mediator.Send(new DeleteMedicineCommandRequest { Id = id });
         return NoContent();
     }

     [HttpGet("{id}")]
     public async Task<IActionResult> GetById(Guid id)
     {
         var medicine = await _mediator.Send(new GetMedicineByIdQueryRequest { Id = id });
         return Ok(medicine);
     }

     [HttpGet]
     public async Task<IActionResult> GetAll()
     {
         var medicines = await _mediator.Send(new GetAllMedicinesQueryRequest());
         return Ok(medicines);
     }
 }


            using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class MedicinesController : ControllerBase
{
    private readonly IMedicineService _medicineService;

    public MedicinesController(IMedicineService medicineService)
    {
        _medicineService = medicineService;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] MedicinePostDTO dto)
    {
        var id = await _medicineService.CreateMedicineAsync(dto);
        return CreatedAtAction(nameof(GetById), new { id = id }, null);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] MedicinePostDTO dto)
    {
        await _medicineService.UpdateMedicineAsync(id, dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _medicineService.DeleteMedicineAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var medicine = await _medicineService.GetMedicineByIdAsync(id);
        return Ok(medicine);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var medicines = await _medicineService.GetAllMedicinesAsync();
        return Ok(medicines);
    }
}



             */
        }
    }
}

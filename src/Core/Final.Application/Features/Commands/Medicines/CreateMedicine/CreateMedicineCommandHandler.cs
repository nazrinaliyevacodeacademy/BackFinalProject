using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final.Application.Abstraction.Services;
using MediatR;
using AutoMapper;
using Final.Domain.Entities;
using Microsoft.Extensions.Configuration;

namespace Final.Application.Features.Commands.Medicines.CreateMedicine
{

       public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommandRequest>
    {
        private readonly IMedicineService _medicineService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public CreateMedicineCommandHandler(IMedicineService medicineService, IConfiguration configuration, IMapper mapper)
        {
            _medicineService = medicineService;
            _configuration = configuration;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            var dto = request.Dto;

            // Yükləmə yolu oxunur
            var uploadPath = _configuration["ImageUpload:Path"];
            var fileName = Guid.NewGuid() + Path.GetExtension(dto.Image.FileName);
            var filePath = Path.Combine(uploadPath, fileName);

            Directory.CreateDirectory(uploadPath);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await dto.Image.CopyToAsync(stream);
            }

            // Dto'ya image path əlavə olunur
            dto.ImageUrl = fileName;

            await _medicineService.CreateMedicineAsync(dto);

            return Unit.Value;
        }

        Task IRequestHandler<CreateMedicineCommandRequest>.Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
}
   /* public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommandRequest>
    {
        private readonly IMedicineService _medicineService;
      
        public CreateMedicineCommandHandler(IMedicineService medicineService)
        {
            _medicineService = medicineService;
        }

        public async Task<Unit> Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            await _medicineService.CreateMedicineAsync(request.Dto);
            return Unit.Value;
        }

        Task IRequestHandler<CreateMedicineCommandRequest>.Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
        {
            return Handle(request, cancellationToken);
        }
    }
*/


    /*
     namespace Final.Application.Features.Commands.Medicines.CreateMedicine
     {
         public class CreateMedicineCommandHandler : IRequestHandler<CreateMedicineCommandRequest>
         {
             private readonly FinalDbContext _context;
             private readonly IMapper _mapper;

             public CreateMedicineCommandHandler(FinalDbContext context, IMapper mapper)
             {
                 _context = context;
                 _mapper = mapper;
             }

             public async Task<Unit> Handle(CreateMedicineCommandRequest request, CancellationToken cancellationToken)
             {
                 var dto = request.Dto;

                 // Şəkili upload et
                 var fileName = Guid.NewGuid() + Path.GetExtension(dto.Image.FileName);
                 var filePath = Path.Combine("wwwroot", "uploads", fileName);

                 Directory.CreateDirectory(Path.GetDirectoryName(filePath)); // Əmin ol ki, wwwroot/uploads mövcuddur

                 using (var stream = new FileStream(filePath, FileMode.Create))
                 {
                     await dto.Image.CopyToAsync(stream);
                 }

                 // DTO-dan Medicine obyektinə keçid
                 var medicine = _mapper.Map<Medicine>(dto);
                 medicine.ImageUrl = "/uploads/" + fileName;

                 await _context.Medicines.AddAsync(medicine, cancellationToken);
                 await _context.SaveChangesAsync(cancellationToken);

                 return Unit.Value;
             }
         }
    } }*/



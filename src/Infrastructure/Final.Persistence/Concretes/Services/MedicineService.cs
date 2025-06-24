using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using Final.Domain.Entities;
using Final.Domain.Exceptions;


namespace Final.Persistence.Concretes.Services;
public class MedicineService : IMedicineService
{
    private readonly IMedicineReadRepository _readRepository;
    private readonly IMedicineWriteRepository _writeRepository;
    private readonly IMapper _mapper;
    public MedicineService(IMedicineReadRepository readRepository, IMedicineWriteRepository writeRepository, IMapper mapper)
    {
        _readRepository = readRepository;
        _writeRepository = writeRepository;
        _mapper = mapper;
    }

    public async Task CreateMedicineAsync(MedicinePostDTO medicinePostDTO)
    {
        Medicine medicine = _mapper.Map<Medicine>(medicinePostDTO);
       await _writeRepository.CreateAsync(medicine);
    }

    public async Task<MedicineGetDTO> GetMedicineByIdAsync(Guid id,bool isTracking)
    {
      Medicine? medicine =await _readRepository.GetByIdAsync(id);
   
        if (medicine == null)
        {
            throw new MedicineException($"Medicine not found with {id}");
        }
        MedicineGetDTO medicineGetDto = _mapper.Map<MedicineGetDTO>(medicine);
        return medicineGetDto;

      

    }
}

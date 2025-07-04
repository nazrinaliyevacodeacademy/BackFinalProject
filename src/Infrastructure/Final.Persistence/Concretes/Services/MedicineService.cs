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
  
    /*    public async Task<Guid> CreateMedicineAsync(MedicinePostDTO dto)
        {
            var medicine = _mapper.Map<Medicine>(dto);
            await _writeRepository.CreateAsync(medicine);
            return medicine.Id;
        }*/

        public async Task UpdateMedicineAsync(Guid id, MedicinePostDTO dto)
        {
            var medicine = await _readRepository.GetByIdAsync(id);
            if (medicine == null)
                throw new Exception("Medicine not found");

            _mapper.Map(dto, medicine);
            await _writeRepository.UpdateAsync(medicine);
        }

        public async Task DeleteMedicineAsync(Guid id)
        {
            await _writeRepository.DeleteAsync(id);
        }

        public async Task<MedicineGetDTO> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _readRepository.GetByIdAsync(id);
            if (medicine == null)
                throw new Exception("Medicine not found");

            return _mapper.Map<MedicineGetDTO>(medicine);
        }

        public async Task<List<MedicineGetDTO>> GetAllMedicinesAsync()
        {
            var medicines = await _readRepository.GetAllAsync();
            return _mapper.Map<List<MedicineGetDTO>>(medicines);
        }
    

}

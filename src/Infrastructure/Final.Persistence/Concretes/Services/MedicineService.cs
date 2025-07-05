using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Final.Application.Abstraction.Repositories;
using Final.Application.Abstraction.Services;
using Final.Application.DTOs.Medicine;
using Final.Application.Exceptions;
using Final.Domain.Entities;

namespace Final.Persistence.Concretes.Services;
public class MedicineService : IMedicineService
    
{
        private readonly IMedicineReadRepository _readRepository;
        private readonly IMedicineWriteRepository _writeRepository;
        private readonly IMapper _mapper;

        public MedicineService(
            IMedicineReadRepository readRepository,
            IMedicineWriteRepository writeRepository,
            IMapper mapper)
        {
            _readRepository = readRepository;
            _writeRepository = writeRepository;
            _mapper = mapper;
        }

        public async Task CreateMedicineAsync(MedicinePostDTO medicnePostDTO)
        {
            if (medicnePostDTO.Price <= 0)
                throw new BusinessException("Price must be greater than 0");

            var medicine = _mapper.Map<Medicine>(medicnePostDTO);
            await _writeRepository.CreateAsync(medicine);
            await _writeRepository.SaveChangesAsync();
        }

        public async Task<MedicineGetDTO> GetMedicineByIdAsync(Guid id)
        {
            var medicine = await _readRepository.GetByIdAsync(id);
            if (medicine == null)
                throw new NotFoundException($"Medicine not found with ID: {id}");

            return _mapper.Map<MedicineGetDTO>(medicine);
        }

        public async Task<List<MedicineGetDTO>> GetAllMedicinesAsync()
        {
            var medicines = await _readRepository.GetAllAsync();
            return _mapper.Map<List<MedicineGetDTO>>(medicines);
        }

        public async Task UpdateMedicineAsync(Guid id, MedicinePostDTO dto)
        {
            var medicine = await _readRepository.GetByIdAsync(id);
            if (medicine == null)
                throw new NotFoundException("Medicine not found");

            if (dto.Price <= 0)
                throw new BusinessException("Price must be greater than 0");

            _mapper.Map(dto, medicine);
            await _writeRepository.UpdateAsync(medicine);
            await _writeRepository.SaveChangesAsync();
        }

        public async Task DeleteMedicineAsync(Guid id)
        {
            var medicine = await _readRepository.GetByIdAsync(id);
            if (medicine == null)
                throw new NotFoundException("Medicine not found");

            await _writeRepository.DeleteAsync(id);
            await _writeRepository.SaveChangesAsync();
        }
    
}

    


 

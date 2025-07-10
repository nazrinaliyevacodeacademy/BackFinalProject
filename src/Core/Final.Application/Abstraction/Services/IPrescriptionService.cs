using Final.Application.DTOs.Prescription;

public interface IPrescriptionService
{
    Task<Guid> CreateAsync(CreatePrescriptionDTO dto);
    Task<List<PrescriptionDto>> GetAllAsync();
    Task<PrescriptionDto> GetByIdAsync(Guid id);
    Task<bool> UpdateAsync(UpdatePrescriptionDTO dto);
    Task<bool> DeleteAsync(Guid id);
}

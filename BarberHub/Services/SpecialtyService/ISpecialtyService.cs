using BarberHub.DTOs.SpecialtyDTO;
using BarberHub.Models;

namespace BarberHub.Services.SpecialtyService
{
    public interface ISpecialtyService
    {
        Task<Specialty> AddSpecialty(AddSpecialtyDTO DTO);
        Task<List<Specialty>> GetSpecialties();
        Task<DisplaySpecialtyDTO> GetSpecificSpecialty(int specialtyID);
        Task<Specialty> UpdateSpecialty(UpdateSpecialtyDTO DTO);
    }
}
using BarberHub.Context;
using BarberHub.DTOs.SpecialtyDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.SpecialtyService
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly DataContext _context;
        public SpecialtyService(DataContext contex)
        {
            _context = contex;
        }

        public async Task<Specialty> AddSpecialty(AddSpecialtyDTO DTO)
        {
            Specialty specialty = new Specialty();
            specialty.SpecialtyName = DTO.SpecialtyName;

            await _context.Specialties.AddAsync(specialty);
            await _context.SaveChangesAsync();
            return specialty;
        }
        public async Task<Specialty> UpdateSpecialty(UpdateSpecialtyDTO DTO)
        {
            var specialty = await _context.Specialties.Where(s => s.SpecialtyId == DTO.SpecialtyId).FirstOrDefaultAsync();
            if (specialty == null)
            {
                throw new Exception("Specialty not found");
            }
            specialty.SpecialtyName = DTO.SpecialtyName;
            _context.Specialties.Update(specialty);
            await _context.SaveChangesAsync();
            return specialty;
        }

        public async Task<List<Specialty>> GetSpecialties()
        {
            var specialties = await _context.Specialties.ToListAsync();
            return specialties;
        }

        public async Task<DisplaySpecialtyDTO> GetSpecificSpecialty(int specialtyID)
        {
            var specialty = await _context.Specialties.Where(s => s.SpecialtyId == specialtyID)
                .Include(s => s.Portfolios)
                    .ThenInclude(p => p.User)
                .FirstOrDefaultAsync();

            if (specialty == null)
            {
                throw new Exception("Specialty Not Found");
            }

            var specialtyDTO = new DisplaySpecialtyDTO
            {
                SpecialtyId = specialtyID,
                SpecialtyName = specialty.SpecialtyName,
                Portfolios = specialty.Portfolios.Select(p => new PortfolioSummaryDTO
                {
                    PortfolioId = p.PortfolioId,
                    Title = p.Title,
                    YearsOfExperience = p.YearsOfExperience,
                    User = new UserSummaryDTO
                    {
                        UserId = p.User.UserId,
                        UserName = p.User.UserName,

                    }
                }).ToList()
            };

            return specialtyDTO;

        }
    }
}

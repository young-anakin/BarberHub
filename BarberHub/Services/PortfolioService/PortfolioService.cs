using BarberHub.Context;
using BarberHub.DTOs.PortfolioDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace BarberHub.Services.PortfolioService
{
    public class PortfolioService : IPortfolioService
    {
        private readonly DataContext _context;

        public PortfolioService(DataContext context)
        {
            _context = context;
        }

        public async Task<Portfolio> AddPortfolio(AddPortfolioDTO DTO)
        {
            Portfolio portfolio = new Portfolio();
            portfolio.Title = DTO.Title;
            portfolio.Bio = DTO.Bio;
            portfolio.YearsOfExperience = DTO.YearsOfExperience;
            portfolio.UserId = DTO.UserId;
            portfolio.Specialties = new List<Specialty>();

            var specialties = await _context.Specialties
                .Where(s => DTO.SpecialtyIds.Contains(s.SpecialtyId))
                .ToListAsync();

            foreach (var specialty in specialties)
            {
                portfolio.Specialties.Add(specialty);
            }

            await _context.Portfolios.AddAsync(portfolio);
            await _context.SaveChangesAsync();
            return portfolio;
        }

        public async Task<Portfolio> UpdatePortfolio(UpdatePortfolioDTO dto)
        {
            var portfolio = await _context.Portfolios
                .Include(p => p.Specialties)
                .FirstOrDefaultAsync(p => p.PortfolioId == dto.PortfolioId);

            if (portfolio == null)
                throw new Exception("Portfolio not found");

            // Update scalar properties
            portfolio.Title = dto.Title;
            portfolio.Bio = dto.Bio;
            portfolio.YearsOfExperience = dto.YearsOfExperience;

            // Update specialties
            portfolio.Specialties.Clear();

            var specialties = await _context.Specialties
                .Where(s => dto.SpecialtyIds.Contains(s.SpecialtyId))
                .ToListAsync();

            foreach (var specialty in specialties)
            {
                portfolio.Specialties.Add(specialty);
            }

            await _context.SaveChangesAsync();
            return portfolio;
        }
        public async Task<Portfolio> DisplayPortfolio(int portfolioId)
        {
            var portfolio = await _context.Portfolios.Where(p => p.PortfolioId == portfolioId).Include(p => p.Specialties).FirstOrDefaultAsync();
            if (portfolio == null)
            {
                throw new Exception("Portfolio Not found");
            }
            return portfolio;
        }

        public async Task<List<Portfolio>> DisplayAllPortfolios()
        {
            var portfolios = await _context.Portfolios
                .Include(p => p.Specialties)
                .ToListAsync();
            return portfolios;
        }
    }
}

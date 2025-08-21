using BarberHub.DTOs.PortfolioDTO;

namespace BarberHub.Services.PortfolioService
{
    public interface IPortfolioService
    {
        Task<Portfolio> AddPortfolio(AddPortfolioDTO DTO);
        Task<List<Portfolio>> DisplayAllPortfolios();
        Task<Portfolio> DisplayPortfolio(int portfolioId);
        Task<Portfolio> UpdatePortfolio(UpdatePortfolioDTO dto);
    }
}
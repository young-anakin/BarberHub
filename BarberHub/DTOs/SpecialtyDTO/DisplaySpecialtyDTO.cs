namespace BarberHub.DTOs.SpecialtyDTO
{
    public class DisplaySpecialtyDTO
    {
        public int SpecialtyId { get; set; }

        public string SpecialtyName { get; set; }


        public List<PortfolioSummaryDTO> Portfolios { get; set; }
    }

    public class PortfolioSummaryDTO
    {
        public int PortfolioId { get; set; }

        public string? Title { get; set; }

        public int YearsOfExperience { get; set; }

        public UserSummaryDTO User { get; set; }
    }

    public class UserSummaryDTO
    {
        public int UserId { get; set; }

        public string UserName { get; set; }
    }
}

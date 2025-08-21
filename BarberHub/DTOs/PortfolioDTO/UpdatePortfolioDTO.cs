namespace BarberHub.DTOs.PortfolioDTO
{
    public class UpdatePortfolioDTO
    {
        public int PortfolioId { get; set; }

        public string Title { get; set; }

        public string Bio { get; set; }

        public int YearsOfExperience { get; set; }

        public List<int> SpecialtyIds { get; set; }  // IDs of the selected specialties
    }

}

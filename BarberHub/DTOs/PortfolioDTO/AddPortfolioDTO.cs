namespace BarberHub.DTOs.PortfolioDTO
{
    public class AddPortfolioDTO
    {
        public string Title { get; set; }

        public string Bio {  get; set; }   

        public int YearsOfExperience { get; set; }

        public int UserId { get; set; }

        public List<int> SpecialtyIds { get; set; }  // NEW: services offered by this portfolio

    }
}

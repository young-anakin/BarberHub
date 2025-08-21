using BarberHub.Models;
using System.ComponentModel.DataAnnotations;

public class Portfolio
{
    [Key]
    public int PortfolioId { get; set; }

    public string? Title { get; set; }

    public string? Bio { get; set; }

    public int YearsOfExperience { get; set; }

    public int UserId { get; set; }

    [System.Text.Json.Serialization.JsonIgnore]

    public User User { get; set; }

    public ICollection<Specialty>? Specialties { get; set; }

    public List<Appointment>? Appointments { get; set; }

    public List<PaymentDetail>? PaymentDetails { get; set; }

}

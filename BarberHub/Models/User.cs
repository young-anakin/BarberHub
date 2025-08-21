using BarberHub.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class User
{
    [Key]
    public int UserId { get; set; }

    public string UserName { get; set; }

    public string Password { get; set; }

    public int UserRoleId { get; set; }
    public UserRole UserRole { get; set; }

    public UserProfile UserProfile { get; set; }

    [JsonIgnore]
    public List<Review>? ReceivedReviews { get; set; }

    [JsonIgnore]
    public List<Review>? GivenReviews { get; set; }

    public Portfolio? Portfolio { get; set; }

    public List<Appointment>? Appointments { get; set; }

    public List<Company>? Companies { get; set; }

    [ForeignKey("EmployerCompany")]
    public int? EmployeedCompanyId { get; set; }

    public Company? EmployerCompany { get; set; }

    public List<Payment>? Payments { get; set; }

}

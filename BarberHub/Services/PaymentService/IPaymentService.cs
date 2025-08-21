using BarberHub.DTOs.PaymentDTO;
using BarberHub.Models;

namespace BarberHub.Services.PaymentService
{
    public interface IPaymentService
    {
        Task<Payment> AddPaymentAsync(AddPaymentDTO dto);
        Task<DisplayPaymentDTO> GetPaymentByIdAsync(int paymentId);
    }
}
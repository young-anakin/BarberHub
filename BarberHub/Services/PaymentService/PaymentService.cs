using BarberHub.Context;
using BarberHub.DTOs.PaymentDTO;
using BarberHub.Models;
using Microsoft.EntityFrameworkCore;

namespace BarberHub.Services.PaymentService
{
    public class PaymentService : IPaymentService
    {
        private readonly DataContext _context;

        public PaymentService(DataContext context)
        {
            _context = context;
        }

        public async Task<Payment> AddPaymentAsync(AddPaymentDTO dto)
        {
            // 1. Calculate total
            var totalAmount = dto.PaymentDetails.Sum(p => p.PriceCharged);

            // 2. Create Payment
            var payment = new Payment
            {
                UserId = dto.UserId,
                CompanyId = dto.CompanyId,
                PaymentType = dto.PaymentType,
                TotalAmount = totalAmount,
                PaymentDate = DateTime.UtcNow,
                PaymentDetails = new List<PaymentDetail>()
            };

            // 3. Add PaymentDetails
            foreach (var detail in dto.PaymentDetails)
            {
                var paymentDetail = new PaymentDetail
                {
                    ServiceId = detail.ServiceId,
                    PortfolioId = detail.PortfolioId,
                    PriceCharged = detail.PriceCharged,
                    Notes = detail.Notes
                };

                payment.PaymentDetails.Add(paymentDetail);
            }

            // 4. Save to DB
            await _context.Payments.AddAsync(payment);
            await _context.SaveChangesAsync();

            return payment;
        }

        public async Task<DisplayPaymentDTO> GetPaymentByIdAsync(int paymentId)
        {
            var payment = await _context.Payments
                .Include(p => p.PaymentDetails)
                    .ThenInclude(pd => pd.Service)
                .Include(p => p.PaymentDetails)
                    .ThenInclude(pd => pd.Portfolio)
                        .ThenInclude(port => port.User)
                .FirstOrDefaultAsync(p => p.PaymentId == paymentId);

            if (payment == null)
            {
                throw new Exception("Payment not found");
            }

            var dto = new DisplayPaymentDTO
            {
                PaymentId = payment.PaymentId,
                UserId = payment.UserId,
                CompanyId = payment.CompanyId,
                PaymentType = payment.PaymentType,
                PaymentDate = payment.PaymentDate,
                TotalAmount = payment.TotalAmount,
                PaymentDetails = payment.PaymentDetails.Select(detail => new DisplayPaymentDetailDTO
                {
                    ServiceId = detail.ServiceId,
                    ServiceName = detail.Service?.ServiceName ?? "Unknown",
                    PortfolioId = detail.PortfolioId,
                    BarberName = detail.Portfolio?.User?.UserName ?? "Unknown",
                    PriceCharged = detail.PriceCharged,
                    Notes = detail.Notes
                }).ToList()
            };

            return dto;
        }



    }
}

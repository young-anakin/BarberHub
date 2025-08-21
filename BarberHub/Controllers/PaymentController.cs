using BarberHub.DTOs.AppointmentDTO;
using BarberHub.DTOs.PaymentDTO;
using BarberHub.Services.AppointmentService;
using BarberHub.Services.PaymentService;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : Controller
    {

        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpPost]
        public async Task<ActionResult> MakePayment(AddPaymentDTO DTO)
        {
            try
            {
                var result = await _paymentService.AddPaymentAsync(DTO);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                // ⚠️ Shows the full error and stack trace — helpful for debugging!
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse
                {
                    Message = ex.ToString()
                });
            }
        }


        [HttpGet("SpecificPayment")]
        public async Task<ActionResult> GetSpecificPayment(int paymentId)
        {
            try
            {
                return Ok(await _paymentService.GetPaymentByIdAsync(paymentId));
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new ErrorResponse { Message = ex.Message });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new ErrorResponse { Message = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new ErrorResponse { Message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResponse { Message = "Internal Server Error" });
            }
        }

    }
}

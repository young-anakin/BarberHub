using BarberHub.DTOs.CompanyDTO;
using BarberHub.DTOs.CompanyServiceDTO;
using BarberHub.Services.CompanyProvidedService;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyProvidedServiceController : Controller
    {
        private readonly ICompanyProvidedService _service;

        public CompanyProvidedServiceController(ICompanyProvidedService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCompanyProvidedService(CreateProvidedServiceDTO DTO)
        {
            try
            {
                return Ok(await _service.CreateCompanyProvidedService(DTO));
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

        [HttpPut]
        public async Task<ActionResult> UpdateCompanyProvidedService(UpdateProvidedService DTO)
        {
            try
            {
                return Ok(await _service.UpdateCompanyProvidedService(DTO));
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

        [HttpDelete]
        public async Task<ActionResult> DeleteCompanyProvidedService(int id)
        {
            try
            {
                return Ok(await _service.DeleteCompanyService(id));
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

        [HttpGet]
        public async Task<ActionResult> GetCompanyProvidedService(int serviceId)
        {
            try
            {
                return Ok(await _service.DisplayProvidedService(serviceId));
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

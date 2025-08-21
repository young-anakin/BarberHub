using BarberHub.DTOs.PortfolioDTO;
using BarberHub.DTOs.SpecialtyDTO;
using BarberHub.Services.SpecialtyService;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : Controller
    {
        private readonly ISpecialtyService _speciatyService;
        public SpecialtyController(ISpecialtyService ss) { 
            _speciatyService = ss;
        }

        [HttpPost]
        public async Task<ActionResult> AddSpecialty(AddSpecialtyDTO DTO)
        {
            try
            {
                return Ok(await _speciatyService.AddSpecialty(DTO));
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
        public async Task<ActionResult> UpdateSpecialty(UpdateSpecialtyDTO DTO)
        {
            try
            {
                return Ok(await _speciatyService.UpdateSpecialty(DTO));
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

        [HttpGet("SpecificSpecialty")]
        public async Task<ActionResult> GetSpecificSpecialty(int specialtyId)
        {
            try
            {
                return Ok(await _speciatyService.GetSpecificSpecialty(specialtyId));
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

        [HttpGet("AllSpecialties")]
        public async Task<ActionResult> GetAllSpecialties()
        {
            try
            {
                return Ok(await _speciatyService.GetSpecialties());
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

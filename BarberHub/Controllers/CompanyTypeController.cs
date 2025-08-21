using BarberHub.DTOs.CompanyDTO;
using BarberHub.DTOs.CompanyTypeDTO;
using BarberHub.Services.CompanyTypeService;
using Microsoft.AspNetCore.Mvc;

namespace BarberHub.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyTypeController : Controller
    {
        private readonly ICompanyTypeService _companyTypeService;

        public CompanyTypeController(ICompanyTypeService companyTypeService)
        {
            _companyTypeService = companyTypeService;
        }

        [HttpPost]
        public async Task<ActionResult> RegisterCompanyType(RegisterCompanyTypeDTO DTO)
        {
            try
            {
                return Ok(await _companyTypeService.RegisterCompanyType(DTO));
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
        public async Task<ActionResult> RemoveCompanyType(int id)
        {
            try
            {
                return Ok(await _companyTypeService.DeleteCompanyType(id));
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
        public async Task<ActionResult> UpdateCompanyTypeId(UpdateCompanyTypeDTO DTO)
        {
            try
            {
                return Ok(await _companyTypeService.UpdateCompanyType(DTO));
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

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetCompanyTypes()
        {
            try
            {
                return Ok(await _companyTypeService.GetAllCompanyTypes());
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
        public async Task<ActionResult> GetCompanyType(int id)
        {
            try
            {
                return Ok(await _companyTypeService.GetCompanyType(id));
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

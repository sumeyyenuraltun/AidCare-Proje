using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.BloodGlucoses;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AidCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BloodGlucoseController : ControllerBase
    {
        private readonly IBloodGlucoseService _bloodGlucoseService;

        public BloodGlucoseController(IBloodGlucoseService bloodGlucoseService)
        {
            _bloodGlucoseService = bloodGlucoseService;
        }

        [HttpGet]
        public ActionResult<List<BloodGlucoseDTO>> GetAll()
        {
            var result = _bloodGlucoseService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult<BloodGlucoseDTO> GetById(int id)
        {
            var result = _bloodGlucoseService.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public ActionResult<BloodGlucoseDTO> Add([FromBody] AddBloodGlucoseDTO dto)
        {
            _bloodGlucoseService.Add(dto);
            return StatusCode(201, "Kan şekeri verisi eklendi.");

        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateBloodGlucoseDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("Id in URL ile body uyuşmuyor.");

            var existing = _bloodGlucoseService.GetById(id);
            if (existing == null)
                return NotFound();

            _bloodGlucoseService.Update(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existing = _bloodGlucoseService.GetById(id);
            if (existing == null)
                return NotFound();

            _bloodGlucoseService.Delete(id);
            return Ok("Başarıyla silindi");
        }
    }
}

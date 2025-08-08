using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.BloodGlucoses;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetAll()
        {
            var result = _bloodGlucoseService.GetAll();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = _bloodGlucoseService.GetById(id);
            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddBloodGlucoseDTO dto)
        {
            _bloodGlucoseService.Add(dto);
            return Ok("Kan şekeri verisi eklendi.");
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateBloodGlucoseDTO dto)
        {
            _bloodGlucoseService.Update(dto);
            return Ok("Kan şekeri verisi güncellendi.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bloodGlucoseService.Delete(id);
            return Ok("Kan şekeri verisi silindi.");
        }
    }
}

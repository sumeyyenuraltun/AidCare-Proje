using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.Users;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AidCare.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            var user = _userService.GetById(id);
            return user is null
                ? NotFound(new { error = "Kullanıcı bulunamadı." })
                : Ok(user);
        }

        [HttpPost]
        public IActionResult Add([FromBody] AddUserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _userService.Add(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.TcNo }, dto);

            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException?.Message ?? "";

                if (message.Contains("UIX_User_TcNo"))
                    return BadRequest(new { error = "Bu TC numarasına sahip bir kullanıcı zaten mevcut." });

                if (message.Contains("UIX_User_Email"))
                    return BadRequest(new { error = "Bu e-posta adresi zaten kayıtlı." });

                if (message.Contains("UIX_User_PhoneNumber"))
                    return BadRequest(new { error = "Bu telefon numarası zaten kayıtlı." });

                return BadRequest(new { error = "Veritabanı hatası oluştu." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Sunucu hatası: {ex.Message}" });
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] UpdateUserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.Id)
                return BadRequest(new { error = "ID uyuşmuyor." });

            try
            {
                var existingUser = _userService.GetById(id);
                if (existingUser == null)
                    return NotFound(new { error = "Güncellenmek istenen kullanıcı bulunamadı." });

                _userService.Update(dto);
                return NoContent();
            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException?.Message ?? "";

                if (message.Contains("UIX_User_TcNo"))
                    return BadRequest(new { error = "Bu TC numarasına sahip başka bir kullanıcı zaten mevcut." });

                if (message.Contains("UIX_User_Email"))
                    return BadRequest(new { error = "Bu e-posta adresi başka bir kullanıcı tarafından kullanılıyor." });

                if (message.Contains("UIX_User_PhoneNumber"))
                    return BadRequest(new { error = "Bu telefon numarası başka bir kullanıcı tarafından kullanılıyor." });

                return BadRequest(new { error = "Veritabanı hatası oluştu." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Sunucu hatası: {ex.Message}" });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingUser = _userService.GetById(id);
                if (existingUser == null)
                    return NotFound(new { error = "Silinmek istenen kullanıcı bulunamadı." });

                _userService.Delete(id);
                return Ok(new { message = "Kullanıcı başarıyla silindi." });

            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Sunucu hatası: {ex.Message}" });
            }
        }
    }
}

using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.Users;
using AidCare.Entities.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
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

        [HttpPost]
        public IActionResult Add([FromBody] AddUserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                _userService.Add(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.TcNo }, "Kullanıcı başarıyla eklendi.");
            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException?.Message ?? "";

                if (message.Contains("UIX_User_TcNo"))
                    return BadRequest("Bu TC numarasına sahip bir kullanıcı zaten mevcut.");

                if (message.Contains("UIX_User_Email"))
                    return BadRequest("Bu e-posta adresi zaten kayıtlı.");

                if (message.Contains("UIX_User_PhoneNumber"))
                    return BadRequest("Bu telefon numarası zaten kayıtlı.");

                return BadRequest("Veritabanı hatası oluştu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateUserDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var existingUser = _userService.GetById(dto.Id);
                if (existingUser == null)
                    return NotFound("Güncellenmek istenen kullanıcı bulunamadı.");

                _userService.Update(dto);
                return Ok("Kullanıcı başarıyla güncellendi.");
            }
            catch (DbUpdateException ex)
            {
                var message = ex.InnerException?.Message ?? "";

                if (message.Contains("UIX_User_TcNo"))
                    return BadRequest("Bu TC numarasına sahip başka bir kullanıcı zaten mevcut.");

                if (message.Contains("UIX_User_Email"))
                    return BadRequest("Bu e-posta adresi başka bir kullanıcı tarafından kullanılıyor.");

                if (message.Contains("UIX_User_PhoneNumber"))
                    return BadRequest("Bu telefon numarası başka bir kullanıcı tarafından kullanılıyor.");

                return BadRequest("Veritabanı hatası oluştu.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var existingUser = _userService.GetById(id);
                if (existingUser == null)
                    return NotFound("Silinmek istenen kullanıcı bulunamadı.");

                _userService.Delete(id);
                return Ok("Kullanıcı başarıyla silindi.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet]
        public ActionResult<List<UserDTO>> GetAll()
        {
            try
            {
                var users = _userService.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<UserDTO> GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user == null)
                    return NotFound("Kullanıcı bulunamadı.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Sunucu hatası: {ex.Message}");
            }
        }
    }
}

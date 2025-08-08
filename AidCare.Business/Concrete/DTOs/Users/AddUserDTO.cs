using AidCare.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete.DTOs.Users
{
    public class AddUserDTO
    {
        [Required(ErrorMessage = "TcNo alanı zorunludur.")]
        public string TcNo { get; set; } = string.Empty;
        [Required(ErrorMessage = "İsim alanı zorunludur.")]
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Soyaad alanı zorunludur.")]
        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        public decimal? Weight { get; set; }

        public int? Height { get; set; }

        public Gender? Gender { get; set; }

    }

}

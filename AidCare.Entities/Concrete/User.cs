using AidCare.Entities.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Entities.Entity
{
    public class User: BaseEntity
    {
        public User()
        {
            TcNo = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        [Required(ErrorMessage = "TC Kimlik Numarası gereklidir.")]
        [StringLength(11, ErrorMessage = "TC Kimlik Numarası 11 karakter olmalıdır.")]
        public string TcNo { get; set; }
        [Required(ErrorMessage = "Ad gereklidir.")]
        [StringLength(50, ErrorMessage = "Ad 50 karakterden uzun olmamalıdır.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage ="Soyad gereklidir")]
        [StringLength(50, ErrorMessage = "Soyad 50 karakterden uzun olmamalıdır.")]
        public string LastName { get; set; }
        public string FullName => string.Join(" ", FirstName, LastName);
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public decimal? Weight { get; set; }
        public int? Height { get; set; }
        public Gender? gender { get; set; }

        public DateTime? BirthDate { get; set; }

        public int Age =>DateTime.UtcNow.Year -(BirthDate?.Year ?? DateTime.UtcNow.Year) -
                          (DateTime.UtcNow.Month < (BirthDate?.Month ?? 1) ||
                           (DateTime.UtcNow.Month == (BirthDate?.Month ?? 1) &&
                            DateTime.UtcNow.Day < (BirthDate?.Day ?? 1)) ? 1 : 0);
    }
}

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


        public string TcNo { get; set; } = string.Empty;

        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;
        public string FullName => string.Join(" ", FirstName, LastName);
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
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

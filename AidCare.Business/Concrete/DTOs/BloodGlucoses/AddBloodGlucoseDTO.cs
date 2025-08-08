using AidCare.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete.DTOs.BloodGlucoses
{
    public class AddBloodGlucoseDTO
    {
        public int UserId { get; set; }
        public DateTime MeasurementDate { get; set; } = DateTime.UtcNow;
        public MeasurementType MeasurementType { get; set; }
        public decimal MeasurementValue { get; set; }
    }
}

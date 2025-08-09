using AidCare.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete.DTOs.BloodGlucoses
{
    public class BloodGlucoseDTO
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime MeasurementDate { get; set; }
        public MeasurementType MeasurementType { get; set; }
        public decimal MeasurementValue { get; set; }
    }
}

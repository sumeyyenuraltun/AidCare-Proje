using AidCare.Entities.Enum;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Entities.Entity
{
    public class BloodGlucose: BaseEntity
    {

        public int UserId { get; set; }
        public User User { get; set; }
        public DateTime MeasurementDate { get; set; } = DateTime.UtcNow;
        public MeasurementType MeasurementType { get; set; }
        public decimal MeasurementValue { get; set; }
    }
}

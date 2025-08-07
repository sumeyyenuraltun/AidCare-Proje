using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Abtract
{
    public interface IBloodGlucoseDAL
    {
        void Add(BloodGlucose bloodGlucose);
        void Update(BloodGlucose bloodGlucose);
        void Delete(BloodGlucose bloodGlucose);
        List<BloodGlucose> GetAll();
    }
}

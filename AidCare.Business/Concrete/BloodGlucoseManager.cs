using AidCare.Business.Abstract;
using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete
{
    public class BloodGlucoseManager : IBloodGlucoseService
    {
        private readonly IBloodGlucoseDAL _bloodGlucoseDAL;

        public BloodGlucoseManager(IBloodGlucoseDAL bloodGlucoseDAL)
        {
            _bloodGlucoseDAL = bloodGlucoseDAL;
        }

        public void Add(BloodGlucose entity)
        {
            _bloodGlucoseDAL.Add(entity);
        }

        public void Delete(BloodGlucose entity)
        {
            _bloodGlucoseDAL.Delete(entity);
        }

        public List<BloodGlucose> GetAll()
        {
           return _bloodGlucoseDAL.GetAll();
        }

        public void Update(BloodGlucose entity)
        {
            _bloodGlucoseDAL.Update(entity);
        }
    }
}

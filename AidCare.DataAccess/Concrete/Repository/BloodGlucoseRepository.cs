using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.Entities.Entity;

namespace AidCare.DataAccess.Concrete.Repository
{
    public class BloodGlucoseRepository : IBloodGlucoseDAL
    {
        private readonly AidCareDbContext _context;
        public BloodGlucoseRepository(AidCareDbContext context)
        {
            _context = context;
        }
        public void Add(BloodGlucose bloodGlucose)
        {
            _context.BloodGlucoses.Add(bloodGlucose);
            _context.SaveChanges();
        }

        public void Delete(BloodGlucose bloodGlucose)
        {
            _context.BloodGlucoses.Remove(bloodGlucose);
            _context.SaveChanges();
        }

        public List<BloodGlucose> GetAll()
        {
            return _context.BloodGlucoses.ToList();
        }

        public void Update(BloodGlucose bloodGlucose)
        {
            _context.BloodGlucoses.Update(bloodGlucose);
            _context.SaveChanges();
        }
    }
}

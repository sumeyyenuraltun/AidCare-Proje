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
    public class BloodGlucoseRepository : BaseRepository<BloodGlucose>, IBloodGlucoseDAL
    {
       
        public BloodGlucoseRepository(AidCareDbContext context): base(context)
        {
       
        }
       
    }
}

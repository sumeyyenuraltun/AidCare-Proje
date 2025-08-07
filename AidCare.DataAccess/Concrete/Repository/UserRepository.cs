using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.DataAccess.Concrete.Repository;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess1.Repository
{
    public class UserRepository: BaseRepository<User>, IUserDAL
    {
   
        public UserRepository(AidCareDbContext context): base(context)
        {
            
        }

        
    }
}

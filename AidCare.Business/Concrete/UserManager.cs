using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.DataAccess1.Repository;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Concrete
{
    public class UserManager
    {
        private readonly IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public void Add(User user)
        {
            _userDAL.Add(user);
        }

        public void Delete(User user)
        {
            _userDAL.Delete(user);
        }
    }
}

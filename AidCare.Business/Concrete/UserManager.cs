using AidCare.Business.Abstract;
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
    public class UserManager : IUserService
    {
        private readonly IUserDAL _userDAL;
        public UserManager(IUserDAL userDAL)
        {
            _userDAL = userDAL;
        }
        public void Add(User entity)
        {
            _userDAL.Add(entity);
        }

        public void Delete(User entity)
        {
            _userDAL.Delete(entity);
        }

        public List<User> GetAll()
        {
            return _userDAL.GetAll();
        }

        public void Update(User entity)
        {
           _userDAL.Update(entity);
        }
    }
}

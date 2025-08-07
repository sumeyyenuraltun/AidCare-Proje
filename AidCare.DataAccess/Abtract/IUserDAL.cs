using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Abtract
{
    public interface IUserDAL
    {
        void Add(User user);
        void Update(User user);
        void Delete(User user);
        List<User> GetAll();

    }
}

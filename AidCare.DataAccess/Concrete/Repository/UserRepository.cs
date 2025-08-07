using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess1.Repository
{
    public class UserRepository: IUserDAL
    {
        private readonly AidCareDbContext _context;
   
        public UserRepository(AidCareDbContext context)
        {
            _context = context;
        }

        public void Add(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            
        }
        public void Update(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void Delete(User user)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }
    }
}

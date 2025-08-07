using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Concrete.Repository
{
    public class BaseRepository<TEntity> : IBaseDAL<TEntity> where TEntity : class
    {
        private readonly AidCareDbContext _context;

        public BaseRepository(AidCareDbContext context)
        {
            _context = context;
        }

        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();

        }
        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            _context.SaveChanges();
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            _context.SaveChanges();
        }
        public List<TEntity> GetAll()
        {
            return _context.Set<TEntity>().ToList();
        }
    }
}

using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.DataAccess.Abtract
{
    public interface IBaseDAL<TEntity> where TEntity: class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        List<TEntity> GetAll();
    }
}

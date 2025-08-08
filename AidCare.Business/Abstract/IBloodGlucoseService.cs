using AidCare.Business.Concrete.DTOs.BloodGlucoses;
using AidCare.Business.Concrete.DTOs.Users;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Abstract
{
    public interface IBloodGlucoseService 
    {
        void Add(AddBloodGlucoseDTO addBloodGlucoseDTO);
        void Update(UpdateBloodGlucoseDTO updateBloodGlucoseDTO);
        void Delete(int id);
        BloodGlucoseDTO GetById(int id);
        List<BloodGlucoseDTO> GetAll();

    }
}

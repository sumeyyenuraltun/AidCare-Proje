using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.BloodGlucoses;
using AidCare.DataAccess.Abtract;
using AidCare.Entities.Entity;
using AutoMapper;
using System.Collections.Generic;

namespace AidCare.Business.Concrete
{
    public class BloodGlucoseManager : IBloodGlucoseService
    {
        private readonly IBloodGlucoseDAL _bloodGlucoseDAL;
        private readonly IMapper _mapper;

        public BloodGlucoseManager(IBloodGlucoseDAL bloodGlucoseDAL, IMapper mapper)
        {
            _bloodGlucoseDAL = bloodGlucoseDAL;
            _mapper = mapper;
        }

        public void Add(AddBloodGlucoseDTO addDTO)
        {
            var bloodGlucose = _mapper.Map<BloodGlucose>(addDTO);
            _bloodGlucoseDAL.Add(bloodGlucose);
        }

        public void Delete(int id)
        {
            var bloodGlucose = _bloodGlucoseDAL.GetById(id);
            if (bloodGlucose != null)
            {
                _bloodGlucoseDAL.Delete(bloodGlucose);
            }
        }

        public BloodGlucoseDTO GetById(int id)
        {
            var bloodGlucose = _bloodGlucoseDAL.GetById(id);
            return _mapper.Map<BloodGlucoseDTO>(bloodGlucose);
        }

        public List<BloodGlucoseDTO> GetAll()
        {
            var list = _bloodGlucoseDAL.GetAll();
            return _mapper.Map<List<BloodGlucoseDTO>>(list);
        }

        public void Update(UpdateBloodGlucoseDTO updateBloodGlucoseDTO)
        {
            var existingBloodGlucose = _bloodGlucoseDAL.GetById(updateBloodGlucoseDTO.Id);
            if (existingBloodGlucose == null)
                throw new Exception("Kan şekeri ölçümü bulunamadı.");

            _mapper.Map(updateBloodGlucoseDTO, existingBloodGlucose);

            _bloodGlucoseDAL.Update(existingBloodGlucose);
        }

    }
}

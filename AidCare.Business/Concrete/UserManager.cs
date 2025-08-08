using AidCare.Business.Abstract;
using AidCare.Business.Concrete.DTOs.Users;
using AidCare.DataAccess.Abtract;
using AidCare.DataAccess.Concrete.Context;
using AidCare.DataAccess1.Repository;
using AidCare.Entities.Entity;
using AutoMapper;
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
        private readonly IMapper _mapper;

        public UserManager(IUserDAL userDAL, IMapper mapper)
        {
            _userDAL = userDAL;
            _mapper = mapper;
        }

        public void Add(AddUserDTO addUserDTO)
        {
            var user = _mapper.Map<User>(addUserDTO);
            _userDAL.Add(user);
        }

        public void Update(UpdateUserDTO updateUserDTO)
        {
            var user = _mapper.Map<User>(updateUserDTO);
            _userDAL.Update(user);
        }

        public void Delete(int id)
        {
            var user = _userDAL.GetById(id);
            if (user != null)
            {
                _userDAL.Delete(user);
            }
        }

        public UserDTO GetById(int id)
        {
            var user = _userDAL.GetById(id);
            return _mapper.Map<UserDTO>(user);
        }

        public List<UserDTO> GetAll()
        {
            var users = _userDAL.GetAll();
            return _mapper.Map<List<UserDTO>>(users);
        }
    }
}

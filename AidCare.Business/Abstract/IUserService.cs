using AidCare.Business.Concrete.DTOs.Users;
using AidCare.Entities.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AidCare.Business.Abstract
{
    public interface IUserService 
    {
        void Add(AddUserDTO addUserDTO);
        void Update(UpdateUserDTO updateUserDTO);
        void Delete(int id);
        UserDTO GetById(int id);
        List<UserDTO> GetAll();

    }
}

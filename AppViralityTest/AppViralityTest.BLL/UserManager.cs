using AppViralityTest.DAL.Core.Models;
using AppViralityTest.DAL.Persistance;
using AppViralityTest.DataModels;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppViralityTest.BLL
{
    public class UserManager
    {
        public bool IsUserValid(UserDTO user) {
            using (var unitOfWork = new UnitOfWork()) {
                var _user = Mapper.Map<User>(user);
                return unitOfWork.Users.Any(q => q.Name == user.UserName && q.Password == user.Password);
            }
        }

        public UserDTO GetUserDetails(UserDTO user)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var _user = unitOfWork.Users.SingleOrDefault(q => q.Name == user.UserName && q.Password == user.Password);
                var _userDto = Mapper.Map<UserDTO>(_user);
                return _userDto;
            }
        }

        public UserDTO GetUserDetails(int Id)
        {
            using (var unitOfWork = new UnitOfWork())
            {
                var _user = unitOfWork.Users.SingleOrDefault(q => q.Id == Id);
                var _userDto = Mapper.Map<UserDTO>(_user);
                return _userDto;
            }
        }
    }
}

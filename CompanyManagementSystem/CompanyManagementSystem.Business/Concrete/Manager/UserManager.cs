using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.DataAccess.Abstract;
using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Concrete.Manager
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddUser(User user)
        {
            _userDal.AddOperation(user);
        }

        public bool AddUserTransaction(string username)
        {
            var transaction = _userDal.GetOperation(x=>x.Username == username);
            if (transaction != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public User CheckUser(string username, string password)
        {
           return _userDal.GetOperation(x => x.Username == username && x.Password == password);
           
        }

        public void DeleteUser(User user)
        {
            _userDal.DeleteOperation(user);
        }

        public List<UserDetails> GetAllUserDetails()
        {
            return _userDal.GetAllUserDetails();
        }

        public User GetUserId(int userId)
        {
            return _userDal.GetOperation(x=>x.UserId == userId);
        }

        public List<UserRoleDetail> GetUserRole(string username)
        {
            return _userDal.GetPersonRole(username);
        }

        public void UpdateUser(User user)
        {
            _userDal.UpdateOperation(user);
        }
    }
}

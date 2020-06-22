using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Abstract
{
    public interface IUserService
    {
        User CheckUser(string username, string password);
        List<UserRoleDetail> GetUserRole(string username);
        List<UserDetails> GetAllUserDetails();
        void AddUser(User user);
        void DeleteUser(User user);
        void UpdateUser(User user);
        User GetUserId(int userId);
        bool AddUserTransaction(string username);
    }
}

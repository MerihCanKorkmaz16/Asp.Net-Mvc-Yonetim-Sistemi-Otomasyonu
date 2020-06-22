using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.DataAccess.Abstract;
using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Concrete.Manager
{
    public class RoleManager : IRoleService
    {
        private IUserRoleDal _userRoleDal;
        public RoleManager(IUserRoleDal userRoleDal)
        {
            _userRoleDal = userRoleDal;
        }

        public void AddRole(UserRole userRole)
        {
            _userRoleDal.AddOperation(userRole);
        }

        public void DeleteRol(UserRole userRole)
        {
            _userRoleDal.DeleteOperation(userRole);
        }

        public List<UserRole> GetAllRole()
        {
            return _userRoleDal.ListOperation();
        }

        public UserRole GetRole(int roleıd)
        {
            return _userRoleDal.GetOperation(x=>x.RoleId == roleıd);
        }
    }
}

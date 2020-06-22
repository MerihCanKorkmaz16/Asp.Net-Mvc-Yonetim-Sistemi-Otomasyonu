using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Abstract
{
    public interface IRoleService
    {
        List<UserRole> GetAllRole();
        void DeleteRol(UserRole userRole);
        UserRole GetRole(int roleıd);
        void AddRole(UserRole userRole);
    }
}

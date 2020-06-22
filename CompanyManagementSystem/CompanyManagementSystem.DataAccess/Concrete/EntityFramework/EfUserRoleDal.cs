using CompanyManagementSystem.DataAccess.Abstract;
using CompanyManagementSystem.DataAccess.Concrete.EntityFramework.Base;
using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfUserRoleDal : EfRepositoryBase<UserRole, CompanyContext>, IUserRoleDal
    {
    }
}

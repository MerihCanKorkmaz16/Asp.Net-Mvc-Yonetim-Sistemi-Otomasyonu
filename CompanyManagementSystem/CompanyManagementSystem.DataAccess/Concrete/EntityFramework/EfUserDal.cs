using CompanyManagementSystem.DataAccess.Abstract;
using CompanyManagementSystem.DataAccess.Concrete.EntityFramework.Base;
using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfRepositoryBase<User, CompanyContext>, IUserDal
    {
        public List<UserDetails> GetAllUserDetails()
        {
            using (CompanyContext context = new CompanyContext())
            {
                var result = from p in context.User
                             join c in context.UserRole on p.RoleId equals c.RoleId
                             select new UserDetails
                             {
                                 UserId = p.UserId,
                                 RoleName = c.RoleName,
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 RoleId = c.RoleId,
                                 UserName = p.Username,
                                 Email = p.Email
                             };
                return result.ToList();

            }
        }

        public List<UserRoleDetail> GetPersonRole(string username)
        {
            using (CompanyContext context = new CompanyContext())
            {
                var result = from p in context.User
                             join c in context.UserRole on p.RoleId equals c.RoleId
                             where p.Username == username
                             select new UserRoleDetail
                             {
                                 UserId = p.UserId,
                                 RoleName = c.RoleName
                             };
                return result.ToList();

            }
        }
    }
}

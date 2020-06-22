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
    public class EfDuyuruDal : EfRepositoryBase<Duyuru, CompanyContext>, IDuyuruDal
    {
        public List<DuyuruDetails> GetAllDuyuru()
        {
            using (CompanyContext context = new CompanyContext())
            {
                var result = from p in context.User
                             join c in context.Duyuru on p.UserId equals c.UserId
                             select new DuyuruDetails
                             {
                                 FirstName = p.FirstName,
                                 LastName = p.LastName,
                                 DuyuruContext = c.Duyurucontext,
                                 DuyuruId = c.DuyuruId,
                                 Durum = c.Durum
                             };
                return result.ToList();

            }
        }
    }
}

using CompanyManagementSystem.DataAccess.Abstract.Repository;
using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.DataAccess.Abstract
{
    public interface IDuyuruDal: IEntityFrameworkRepository<Duyuru>
    {
        List<DuyuruDetails> GetAllDuyuru();
    }
}

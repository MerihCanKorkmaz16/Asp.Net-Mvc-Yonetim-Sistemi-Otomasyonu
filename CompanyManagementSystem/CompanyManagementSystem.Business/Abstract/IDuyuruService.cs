using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Abstract
{
    public interface IDuyuruService
    {
        List<DuyuruDetails> AllGetDuyuru();
        void UpdateDuyuru(Duyuru duyuru);
        void DeleteDuyuru(Duyuru duyuru);
        void AddDuyuru(Duyuru duyuru);
        Duyuru GetDuyuru(int duyuruId);
    }
}

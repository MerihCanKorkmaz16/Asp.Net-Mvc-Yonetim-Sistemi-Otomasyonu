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
    public class DuyuruManager : IDuyuruService
    {
        private IDuyuruDal _duyuruDal;
        public DuyuruManager(IDuyuruDal duyuruDal)
        {
            _duyuruDal = duyuruDal;
        }
        public void AddDuyuru(Duyuru duyuru)
        {
            _duyuruDal.AddOperation(duyuru);
        }

        public List<DuyuruDetails> AllGetDuyuru()
        {
            return _duyuruDal.GetAllDuyuru();
        }

        public void DeleteDuyuru(Duyuru duyuru)
        {
            _duyuruDal.DeleteOperation(duyuru);
        }

        public Duyuru GetDuyuru(int duyuruId)
        {
            return _duyuruDal.GetOperation(x=>x.DuyuruId == duyuruId);
        }

        public void UpdateDuyuru(Duyuru duyuru)
        {
             _duyuruDal.UpdateOperation(duyuru);
        }
    }
}

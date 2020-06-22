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
    public class SatınAlmaManager:ISatınAlmaService
    {
        private IFaturaDal _faturaDal;
        private IAlımTablosuDal _alımTablosuDal;
        public SatınAlmaManager(IFaturaDal faturaDal, IAlımTablosuDal alımTablosuDal)
        {
            _faturaDal = faturaDal;
            _alımTablosuDal = alımTablosuDal;
        }

         
        public void FaturaEkle(Faturalar faturalar)
        {
            _faturaDal.AddOperation(faturalar);
        }

        public List<AlımTablosu> GetAlım(int userId)
        {
            return _alımTablosuDal.ListOperation(x=>x.UserId == userId);
        }

        public Faturalar GetFatura(int faturaId)
        {
            return _faturaDal.GetOperation(x=>x.FaturaId == faturaId);
        }

        public void SatınAlma(AlımTablosu alımTablosu)
        {
            _alımTablosuDal.AddOperation(alımTablosu);
        }
    }
}

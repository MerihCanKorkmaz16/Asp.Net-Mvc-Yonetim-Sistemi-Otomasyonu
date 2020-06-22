using CompanyManagementSystem.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Abstract
{
    public interface ISatınAlmaService
    {
        void FaturaEkle(Faturalar faturalar);
        void SatınAlma(AlımTablosu alımTablosu);
        List<AlımTablosu> GetAlım(int userId);
        Faturalar GetFatura(int faturaId);
    }
}

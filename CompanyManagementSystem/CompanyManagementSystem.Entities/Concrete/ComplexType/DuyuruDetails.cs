using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Entities.Concrete.ComplexType
{
    public class DuyuruDetails
    {
        public int DuyuruId { get; set; }
        public string DuyuruContext { get; set; }
        public bool Durum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}

using CompanyManagementSystem.Entities.Concrete;
using CompanyManagementSystem.Entities.Concrete.ComplexType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyManagementSystem.WebUI.Models
{
    public class UserSettingsModel
    {
        public List<UserDetails> Details { get; set; }
        public List<UserRole> Roles { get; set; }
        public User User { get; set; }
        public string RoleId { get; set; }
    }
}
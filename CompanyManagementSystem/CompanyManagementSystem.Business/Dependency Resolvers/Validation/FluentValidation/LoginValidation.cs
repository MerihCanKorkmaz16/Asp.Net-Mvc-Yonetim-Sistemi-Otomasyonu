using CompanyManagementSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class LoginValidation : AbstractValidator<User>
    {
        public LoginValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz!");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Şifre boş bırakılamaz!");

        }
    }
}

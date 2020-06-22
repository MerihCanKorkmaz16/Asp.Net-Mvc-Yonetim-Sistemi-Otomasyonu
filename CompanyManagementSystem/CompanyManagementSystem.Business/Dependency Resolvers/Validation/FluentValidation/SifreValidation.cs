using CompanyManagementSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class SifreValidation: AbstractValidator<User>
    {
        public SifreValidation()
        {
            RuleFor(x => x.Password).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz!").Length(8,15).WithMessage("Şifreniz 8-15 karakter arası olmalıdır.");
        }
    }
}

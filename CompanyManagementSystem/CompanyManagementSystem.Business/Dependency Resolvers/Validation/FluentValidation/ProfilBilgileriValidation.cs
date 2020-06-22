using CompanyManagementSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class ProfilBilgileriValidation:AbstractValidator<User>
    {
        public ProfilBilgileriValidation()
        {
            RuleFor(x => x.Username).NotEmpty().WithMessage("Kullanıcı Adı boş bırakılamaz!").Length(5,10).WithMessage("Kullanıcı adınız 5 ile 10 karakter arası olmalıdır.");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("İsim boş bırakılamaz!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Soyadı boş bırakılamaz!");
            RuleFor(x => x.Email).NotEmpty().WithMessage("Email adresiniz boş bırakılamaz!").EmailAddress().WithMessage("Email adresinizi uygun formatta giriniz.");
        }
    }
}

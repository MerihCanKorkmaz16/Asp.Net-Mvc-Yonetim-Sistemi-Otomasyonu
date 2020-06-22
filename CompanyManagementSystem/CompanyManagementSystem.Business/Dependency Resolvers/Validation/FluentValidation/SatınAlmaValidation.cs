using CompanyManagementSystem.Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Dependency_Resolvers.Validation.FluentValidation
{
    public class SatınAlmaValidation: AbstractValidator<AlımTablosu>
    {
        public SatınAlmaValidation()
        {
            RuleFor(x => x.Urün).NotEmpty().WithMessage("Ürün ismi boş bırakılamaz!");
            RuleFor(x => x.FirmaAdi).NotEmpty().WithMessage("Firma adı boş bırakılamaz!");
            RuleFor(x => x.Tutar).NotEmpty().WithMessage("Tutar boş bırakılamaz!");

        }
    }
}

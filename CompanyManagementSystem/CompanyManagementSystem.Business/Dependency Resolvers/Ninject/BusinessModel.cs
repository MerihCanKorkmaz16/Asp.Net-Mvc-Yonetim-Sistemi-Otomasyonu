using CompanyManagementSystem.Business.Abstract;
using CompanyManagementSystem.Business.Concrete.Manager;
using CompanyManagementSystem.DataAccess.Abstract;
using CompanyManagementSystem.DataAccess.Concrete.EntityFramework;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyManagementSystem.Business.Dependency_Resolvers.Ninject
{
    public class BusinessModel:NinjectModule
    {
        public override void Load()
        {
            //User model
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IUserDal>().To<EfUserDal>().InSingletonScope();

            //role model
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<IUserRoleDal>().To<EfUserRoleDal>().InSingletonScope();

            //Duyuru mode
            Bind<IDuyuruService>().To<DuyuruManager>().InSingletonScope();
            Bind<IDuyuruDal>().To<EfDuyuruDal>().InSingletonScope();

            //Satın Alma mode

            Bind<ISatınAlmaService>().To<SatınAlmaManager>().InSingletonScope();
            Bind<IFaturaDal>().To<EfFaturaDal>().InSingletonScope();
            Bind<IAlımTablosuDal>().To<EfAlımTablosuDal>().InSingletonScope();

        }
    }
}

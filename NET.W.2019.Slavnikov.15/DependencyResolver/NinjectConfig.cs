using Bank.BLL.Service.Bank;
using Bank.BLL.Service.Base;
using Bank.BLL.Service.GenerationId;
using Bank.DAL.Contexts;
using Ninject;
using System;

namespace DependencyResolver
{
    public static class NinjectConfig
    {
        public static void ConfigurateResolver(this IKernel kernel)
        {
            kernel.Bind<IBank>().To<BaseBank>().InSingletonScope();;
            kernel.Bind<IGenerationIdAccount>().To<GenerationIdAccount>().InSingletonScope();
            kernel.Bind<BankContext>().To<BankContext>();
        }
    }
}

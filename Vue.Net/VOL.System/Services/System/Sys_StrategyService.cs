using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_StrategyService : ServiceBase<Sys_Strategy, ISys_StrategyRepository>, ISys_StrategyService, IDependency
    {
        public Sys_StrategyService(ISys_StrategyRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_StrategyService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_StrategyService>(); }
        }
    }
}

using VOL.System.IRepositories.System;
using VOL.System.IServices.System;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.System;

namespace VOL.System.Services.System
{
    public partial class Sys_PositionService : ServiceBase<Sys_Position, ISys_PositionRepository>, ISys_PositionService, IDependency
    {
        public Sys_PositionService(ISys_PositionRepository repository)
             : base(repository)
        {
           Init(repository);
        }
        public static ISys_PositionService Instance
        {
           get { return AutofacContainerModule.GetService<ISys_PositionService>(); }
        }
    }
}

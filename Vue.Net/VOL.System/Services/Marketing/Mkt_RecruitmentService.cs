using VOL.System.IRepositories.Marketing;
using VOL.System.IServices.Marketing;
using VOL.Core.BaseProvider;
using VOL.Core.Extensions.AutofacManager;
using VOL.Entity.DomainModels.Marketing;

namespace VOL.System.Services.Marketing
{
    public partial class Mkt_RecruitmentService : ServiceBase<MktRecruitment, IMkt_RecruitmentRepository>, IMkt_RecruitmentService, IDependency
    {
        public Mkt_RecruitmentService(IMkt_RecruitmentRepository repository)
             : base(repository) 
        { 
           Init(repository);
        }
        public static IMkt_RecruitmentService Instance
        {
           get { return AutofacContainerModule.GetService<IMkt_RecruitmentService>(); }
        }
    }
}

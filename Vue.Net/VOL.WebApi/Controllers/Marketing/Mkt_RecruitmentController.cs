using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using System.Threading.Tasks;
using VOL.Core.Controllers.Basic;
using VOL.Entity.AttributeManager;
using VOL.Entity.DomainModels.Marketing;
using VOL.System.IServices.Marketing;

namespace VOL.System.Controllers
{
    [Route("api/Mkt_Recruitment")]
    [PermissionTable(Name = "MktRecruitment")]
    public partial class Mkt_RecruitmentController : ApiBaseController<IMkt_RecruitmentService>
    {
        public Mkt_RecruitmentController(IMkt_RecruitmentService service)
        : base("Marketing","Marketing","MktRecruitment", service)
        {
        }
    }
}

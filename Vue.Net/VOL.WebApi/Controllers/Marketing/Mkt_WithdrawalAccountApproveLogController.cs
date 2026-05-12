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
    [Route("api/Mkt_WithdrawalAccountApproveLog")]
    [PermissionTable(Name = "MktWithdrawalAccountApproveLog")]
    public partial class Mkt_WithdrawalAccountApproveLogController : ApiBaseController<IMkt_WithdrawalAccountApproveLogService>
    {
        public Mkt_WithdrawalAccountApproveLogController(IMkt_WithdrawalAccountApproveLogService service)
        : base("Marketing","Marketing","MktWithdrawalAccountApproveLog", service)
        {
        }
    }
}

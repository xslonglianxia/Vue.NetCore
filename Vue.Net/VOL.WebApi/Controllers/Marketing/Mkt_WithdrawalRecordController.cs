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
    [Route("api/Mkt_WithdrawalRecord")]
    [PermissionTable(Name = "MktWithdrawalRecord")]
    public partial class Mkt_WithdrawalRecordController : ApiBaseController<IMkt_WithdrawalRecordService>
    {
        public Mkt_WithdrawalRecordController(IMkt_WithdrawalRecordService service)
        : base("Marketing","Marketing","MktWithdrawalRecord", service)
        {
        }
    }
}

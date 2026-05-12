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
    [Route("api/Mkt_YuebaoTradingFlow")]
    [PermissionTable(Name = "MktYuebaoTradingFlow")]
    public partial class Mkt_YuebaoTradingFlowController : ApiBaseController<IMkt_YuebaoTradingFlowService>
    {
        public Mkt_YuebaoTradingFlowController(IMkt_YuebaoTradingFlowService service)
        : base("Marketing","Marketing","MktYuebaoTradingFlow", service)
        {
        }
    }
}

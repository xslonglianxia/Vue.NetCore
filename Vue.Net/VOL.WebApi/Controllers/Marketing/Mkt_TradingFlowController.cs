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
    [Route("api/Mkt_TradingFlow")]
    [PermissionTable(Name = "MktTradingFlow")]
    public partial class Mkt_TradingFlowController : ApiBaseController<IMkt_TradingFlowService>
    {
        public Mkt_TradingFlowController(IMkt_TradingFlowService service)
        : base("Marketing","Marketing","MktTradingFlow", service)
        {
        }
    }
}

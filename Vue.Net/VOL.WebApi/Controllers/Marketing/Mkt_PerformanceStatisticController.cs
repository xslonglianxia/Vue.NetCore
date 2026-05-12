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
    [Route("api/Mkt_PerformanceStatistic")]
    [PermissionTable(Name = "MktPerformanceStatistic")]
    public partial class Mkt_PerformanceStatisticController : ApiBaseController<IMkt_PerformanceStatisticService>
    {
        public Mkt_PerformanceStatisticController(IMkt_PerformanceStatisticService service)
        : base("Marketing","Marketing","MktPerformanceStatistic", service)
        {
        }
    }
}

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
    [Route("api/Mkt_Statistic")]
    [PermissionTable(Name = "MktStatistic")]
    public partial class Mkt_StatisticController : ApiBaseController<IMkt_StatisticService>
    {
        public Mkt_StatisticController(IMkt_StatisticService service)
        : base("Marketing","Marketing","MktStatistic", service)
        {
        }
    }
}

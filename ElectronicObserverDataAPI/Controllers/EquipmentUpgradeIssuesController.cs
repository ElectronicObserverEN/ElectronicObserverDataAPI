using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicObserverDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentUpgradeIssuesController : ControllerBase
    {
        private ApiDbContext DbContext { get; }

        public EquipmentUpgradeIssuesController(ApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<EquipmentUpgradeIssueModel> Get(DateTime? start)
        {
            return DbContext.EquipmentUpgradeIssues.Where(issue => start == null || issue.AddedOn >= start);
        }

        [HttpPost]
        public void Post(EquipmentUpgradeIssueModel issue)
        {
            issue.AddedOn = DateTime.UtcNow;
            DbContext.EquipmentUpgradeIssues.Add(issue);
            DbContext.SaveChanges();
        }
    }
}
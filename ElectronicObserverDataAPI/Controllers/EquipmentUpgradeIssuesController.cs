using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Handlers;
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
        public IEnumerable<EquipmentUpgradeIssueModel> Get(DateTime? start, IssueState? issueState)
        {
            return DbContext.EquipmentUpgradeIssues
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => issueState == null || issue.IssueState == issueState);
        }

        [HttpPost]
        [CheckForUserAgent]
        public void Post(EquipmentUpgradeIssueModel issue)
        {
            List<EquipmentUpgradeIssueModel> issues = DbContext.EquipmentUpgradeIssues
                .Where(oldIssue => oldIssue.IssueState != IssueState.Closed)
                .Where(oldIssue => oldIssue.HelperId == issue.HelperId)
                .ToList();

            if (issues.Contains(issue)) return;

            issue.AddedOn = DateTime.UtcNow;
            issue.IssueState = IssueState.Opened;
            DbContext.EquipmentUpgradeIssues.Add(issue);
            DbContext.SaveChanges();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}/closeIssue")]
        public ActionResult CloseIssue(int id)
        {
            EquipmentUpgradeIssueModel? issue = DbContext.EquipmentUpgradeIssues.Find(id);
            
            if (issue is null)
            {
                return NotFound();
            }

            issue.IssueState = IssueState.Closed;
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
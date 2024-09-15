using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Handlers;
using ElectronicObserverDataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicObserverDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EquipmentUpgradeCostIssuesController : ControllerBase
    {
        private ApiDbContext DbContext { get; }

        public EquipmentUpgradeCostIssuesController(ApiDbContext dbContext)
        {
            DbContext = dbContext;
        }
        
        [HttpGet]
        [Authorize]
        public IEnumerable<EquipmentUpgradeCostIssueModel> Get(DateTime? start, IssueState? issueState, int? startId)
        {
            return DbContext.EquipmentUpgradeCostIssues
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => startId == null || issue.Id > startId)
                .Where(issue => issueState == null || issue.IssueState == issueState);
        }

        [HttpPost]
        [CheckForUserAgent]
        public void Post(EquipmentUpgradeCostIssueModel issue)
        {
            List<EquipmentUpgradeCostIssueModel> issues = DbContext.EquipmentUpgradeCostIssues
                .Where(oldIssue => oldIssue.IssueState != IssueState.Closed)
                .Where(oldIssue => oldIssue.EquipmentId == issue.EquipmentId)
                .ToList();

            if (issues.Contains(issue)) return;

            issue.AddedOn = DateTime.UtcNow;
            issue.IssueState = IssueState.Opened;
            DbContext.EquipmentUpgradeCostIssues.Add(issue);
            DbContext.SaveChanges();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}/closeIssue")]
        public ActionResult CloseIssue(int id)
        {
            EquipmentUpgradeCostIssueModel? issue = DbContext.EquipmentUpgradeCostIssues.Find(id);
            
            if (issue is null)
            {
                return NotFound();
            }

            issue.IssueState = IssueState.Closed;
            DbContext.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("latest")]
        public List<EquipmentUpgradeCostIssueModel> GetLatestIssue()
        {
            return DbContext.EquipmentUpgradeCostIssues
                .OrderByDescending(d => d.AddedOn)
                .Take(1)
                .ToList();
        }
    }
}
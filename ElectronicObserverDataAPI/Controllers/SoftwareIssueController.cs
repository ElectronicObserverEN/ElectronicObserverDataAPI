using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Handlers;
using ElectronicObserverDataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicObserverDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SoftwareIssueController(ApiDbContext dbContext) : ControllerBase
    {
        private ApiDbContext DbContext { get; } = dbContext;

        [HttpGet]
        [Authorize]
        public IEnumerable<SoftwareIssueModel> Get(DateTime? start, IssueState? issueState)
        {
            return DbContext.SoftwareIssues
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => issueState == null || issue.IssueState == issueState);
        }

        [HttpPost]
        [CheckForUserAgent]
        public void Post(SoftwareIssueModel questData)
        {
            questData.AddedOn = DateTime.UtcNow;
            DbContext.SoftwareIssues.Add(questData);
            DbContext.SaveChanges();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}/closeIssue")]
        public ActionResult CloseIssue(int id)
        {
            SoftwareIssueModel? issue = DbContext.SoftwareIssues.Find(id);

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
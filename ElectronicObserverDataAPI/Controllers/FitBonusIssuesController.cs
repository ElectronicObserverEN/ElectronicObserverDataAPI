using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Handlers;
using ElectronicObserverDataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ElectronicObserverDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FitBonusIssuesController(ApiDbContext dbContext) : ControllerBase
    {
        [HttpGet]
        [Authorize]
        public PaginatedResultModel<FitBonusIssueModel> Get(DateTime? start, IssueState? issueState, int? startId, string? softwareVersion, int skip = 0,
            int take = 20)
        {
            IEnumerable<FitBonusIssueModel> issues = dbContext.FitBonusIssues
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => startId == null || issue.Id > startId)
                .Where(issue => issueState == null || issue.IssueState == issueState)
                .Where(issue => softwareVersion == null || issue.SoftwareVersion.Contains(softwareVersion))
                .OrderByDescending(issue => issue.AddedOn)
                .Skip(skip)
                .Take(take)
                .Include(nameof(FitBonusIssueModel.ActualBonus))
                .Include(nameof(FitBonusIssueModel.ExpectedBonus))
                .Include(nameof(FitBonusIssueModel.Equipments))
                .Include(nameof(FitBonusIssueModel.Ship));

            return new()
            {
                Results = issues,
                TotalCount = dbContext.FitBonusIssues
                    .Where(issue => start == null || issue.AddedOn >= start)
                    .Where(issue => startId == null || issue.Id > startId)
                    .Where(issue => softwareVersion == null || issue.SoftwareVersion.Contains(softwareVersion))
                    .Count(issue => issueState == null || issue.IssueState == issueState),
            };
        }

        [HttpPost]
        [CheckForUserAgent]
        public void Post(FitBonusIssueModel issue)
        {
            issue.AddedOn = DateTime.UtcNow;
            issue.IssueState = IssueState.Opened;
            dbContext.FitBonusIssues.Add(issue);
            dbContext.SaveChanges();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}/closeIssue")]
        public ActionResult CloseIssue(int id)
        {
            FitBonusIssueModel? issue = dbContext.FitBonusIssues.Find(id);

            if (issue is null)
            {
                return NotFound();
            }

            issue.IssueState = IssueState.Closed;
            dbContext.SaveChanges();

            return Ok();
        }
    }
}

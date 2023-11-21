using ElectronicObserverDataAPI.Database;
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
        public IEnumerable<FitBonusIssueModel> Get(DateTime? start, IssueState? issueState)
        {
            return dbContext.FitBonusIssues
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => issueState == null || issue.IssueState == issueState)
                .Include(nameof(FitBonusIssueModel.ActualBonus))
                .Include(nameof(FitBonusIssueModel.ExpectedBonus))
                .Include(nameof(FitBonusIssueModel.Equipments))
                .Include(nameof(FitBonusIssueModel.Ship));
        }

        [HttpPost]
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

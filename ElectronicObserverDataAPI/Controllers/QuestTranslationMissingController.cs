using ElectronicObserverDataAPI.Database;
using ElectronicObserverDataAPI.Handlers;
using ElectronicObserverDataAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectronicObserverDataAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class QuestTranslationMissingController : ControllerBase
    {
        private ApiDbContext DbContext { get; }

        public QuestTranslationMissingController(ApiDbContext dbContext)
        {
            DbContext = dbContext;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<QuestTranslationMissingModel> Get(DateTime? start, IssueState? issueState)
        {
            return DbContext.QuestTranslationMissing
                .Where(issue => start == null || issue.AddedOn >= start)
                .Where(issue => issueState == null || issue.IssueState == issueState);
        }

        [HttpPost]
        [CheckForUserAgent]
        public void Post(QuestTranslationMissingModel questData)
        {
            questData.AddedOn = DateTime.UtcNow;
            DbContext.QuestTranslationMissing.Add(questData);
            DbContext.SaveChanges();
        }

        [HttpPut]
        [Authorize]
        [Route("{id}/closeIssue")]
        public ActionResult CloseIssue(int id)
        {
            QuestTranslationMissingModel? quest = DbContext.QuestTranslationMissing.Find(id);

            if (quest is null)
            {
                return NotFound();
            }

            quest.IssueState = IssueState.Closed;
            DbContext.SaveChanges();

            return Ok();
        }
    }
}
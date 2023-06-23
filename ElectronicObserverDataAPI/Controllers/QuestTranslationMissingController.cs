using ElectronicObserverDataAPI.Database;
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
        public IEnumerable<QuestTranslationMissingModel> Get(DateTime? start)
        {
            return DbContext.QuestTranslationMissing.Where(issue => start == null || issue.AddedOn >= start);
        }

        [HttpPost]
        public void Post(QuestTranslationMissingModel questData)
        {
            questData.AddedOn = DateTime.UtcNow;
            DbContext.QuestTranslationMissing.Add(questData);
            DbContext.SaveChanges();
        }
    }
}
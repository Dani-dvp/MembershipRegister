using MembershipRegister.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MembershipRegister.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompetitionController : ControllerBase
    {
        private MembershipDbContext _membershipDbContext;
        public CompetitionController(MembershipDbContext membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }

        [HttpGet]
        public ActionResult<List<Competition>> getAllCompetitions()
        {
            var competitions = _membershipDbContext.Competitions.ToList();

            return competitions;
        }

        [HttpPost]
        public ActionResult<Competition> AddNewCompetition(string name, string description, string winner)
        {
            var competition = new Competition();

            competition.name = name;
            competition.description = description;
            competition.winner = winner;
            _membershipDbContext.Competitions.Add(competition);
            _membershipDbContext.SaveChanges();

            return Ok(competition);
        }
    }
}

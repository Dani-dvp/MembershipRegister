using MembershipRegister.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MembershipRegister.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SeedController : ControllerBase
    {
        private MembershipDbContext _membershipDbContext;
        public SeedController(MembershipDbContext membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }

        [HttpPost("competitions")]
        public async Task<string> SeedCompetitionsToDatabase()
        {
            if (!_membershipDbContext.Competitions.Any()) {
                var competition1 = new Competition { name = "Map race", description = "Collecting pins in the forest using a map", winner = "Kevin Dani" };
                var competition2 = new Competition { name = "Basketball", description = "Basketball tournament with 12 teams", winner = "Team Hulk" };
                var competition3 = new Competition { name = "Beach Volleyball", description = "Volleyball tournament with 9 teams", winner = "Team Lokomotiv" };


                await _membershipDbContext.Competitions.AddAsync(competition1);
                await _membershipDbContext.Competitions.AddAsync(competition2);
                await _membershipDbContext.Competitions.AddAsync(competition3);

                _membershipDbContext.SaveChanges();
            }
            return "Created Seed";
        }

        [HttpPost("admin")]
        public async Task<string> SeedAdminsToDatabase()
        {
            if (!_membershipDbContext.Administrators.Any()) {
                var admin = new Administrator { userName = "admin", password = "password" };

                await _membershipDbContext.Administrators.AddAsync(admin);

                _membershipDbContext.SaveChanges();
            }
            return "Created Seed";
        }

        [HttpPost("customers")]
        public async Task<string> SeedCustomersToDatabase()
        {
            if (!_membershipDbContext.Customers.Any()) {
                var customer1 = new Customer { firstName = "Kevin", lastName = "Dani", paidFor = "Year" };
                var customer2 = new Customer { firstName = "Helena", lastName = "Boström", paidFor = "Month" };
                var customer3 = new Customer { firstName = "Johan", lastName = "Klum", paidFor = "Half year" };
                var customer4 = new Customer { firstName = "Malin", lastName = "Andersson", paidFor = "Quarter" };
                var customer5 = new Customer { firstName = "Henrik", lastName = "Svensson", paidFor = "Not paid" };

                await _membershipDbContext.Customers.AddAsync(customer1);
                await _membershipDbContext.Customers.AddAsync(customer2);
                await _membershipDbContext.Customers.AddAsync(customer3);
                await _membershipDbContext.Customers.AddAsync(customer4);
                await _membershipDbContext.Customers.AddAsync(customer5);

                _membershipDbContext.SaveChanges();
            }
            return "Created Seed";
        }
    }
}

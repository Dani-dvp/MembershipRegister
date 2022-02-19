using MembershipRegister.API.LoginResponse;
using MembershipRegister.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MembershipRegister.API.Controllers
{
    [ApiController]
    public class AdministratorController : ControllerBase
    {
        private MembershipDbContext _membershipDbContext;
        public AdministratorController(MembershipDbContext membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }
        [HttpGet("adminstrators")]
        public ActionResult<List<Administrator>> GetAllAdministrators()
        {
            var admins = _membershipDbContext.Administrators.ToList();

            return admins;
        }

        [HttpGet("create/administator")]
        public async Task<Administrator> AddAdministrator(string username, string password)
        {
            var admin = new Administrator();
            admin.password = password;
            admin.userName = username;
            _membershipDbContext.Administrators.Add(admin);
            await _membershipDbContext.SaveChangesAsync();

            return admin;
        }

        [HttpGet("administrator/login/{userName}/{password}")]
        public ActionResult<bool> LoginAsAdministrator([FromRoute] string userName, [FromRoute] string password)
        {
            var admins = _membershipDbContext.Administrators.ToList();
            var response = new AdministratorDTO();
            for (int i = 0; i < admins.Count; i++)
            {
                if (admins[i].userName == userName && admins[i].password == password)
                {
                    response.LoggedIn = true;
                }
            }
            return response.LoggedIn;
        }
    }
}

﻿using MembershipRegister.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MembershipRegister.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
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

        [HttpPost("administators")]
        public async Task<Administrator> AddAdministrator(string userName, string password)
        {
            var admin = new Administrator();
            admin.password = password;
            admin.userName = userName;
            _membershipDbContext.Administrators.Add(admin);
            await _membershipDbContext.SaveChangesAsync();

            return admin;
        }

        [HttpGet("login")]
        public ActionResult<Administrator> LoginAsAdministrator(string userName, string password)
        {
            var admins = _membershipDbContext.Administrators.ToList();
            var response = new Administrator();
            for(int i = 0; i < admins.Count; i++)
            {
                if(admins[i].userName == userName && admins[i].password == password)
                {
                    response = admins[i];
                }
            }
            return response;
        }
    }
}

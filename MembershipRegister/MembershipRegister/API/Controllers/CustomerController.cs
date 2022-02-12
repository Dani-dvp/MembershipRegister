using MembershipRegister.Domain;
using Microsoft.AspNetCore.Mvc;

namespace MembershipRegister.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private MembershipDbContext _membershipDbContext;
        public CustomerController(MembershipDbContext membershipDbContext)
        {
            _membershipDbContext = membershipDbContext;
        }

        [HttpGet]
        public ActionResult<List<Customer>> GetAllCustomers()
        {
            var customers = _membershipDbContext.Customers.ToList();

            return customers;
        }


        [HttpPost]
        public ActionResult<Customer> AddNewCustomer(string firstName, string lastName, string paidFor)
        {
            var customer = new Customer();

            customer.firstName = firstName;
            customer.lastName = lastName;
            customer.paidFor = paidFor;

            _membershipDbContext.Customers.Add(customer);

            _membershipDbContext.SaveChanges();

            return Ok(customer);
        }

    }
}

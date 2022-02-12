namespace MembershipRegister.Domain
{
    public class Customer : BaseEntity
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string paidFor { get; set; }
    }
}

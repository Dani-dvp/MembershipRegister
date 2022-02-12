namespace MembershipRegister.Domain
{
    public class Competition : BaseEntity
    {
        public string name { get; set; }
        public string description { get; set; }
        public string winner { get; set; }
    }
}

using ApplicationIdentity.Contracts;
using ApplicationIdentity.Identity;

namespace ApplicationIdentity.Entities
{
    public class Staff : AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StaffNumber { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}

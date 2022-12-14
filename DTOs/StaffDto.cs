using ApplicationIdentity.DTOs;
using System.Collections.Generic;

namespace ApplicationIdentity2.DTOs
{
    public class StaffDto
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string StaffNumber { get; set; }
    }

    public class StaffResponseModel : BaseResponse
    {
        public StaffDto Data { get; set; }
    }

    public class StaffsResponseModel : BaseResponse
    {
        public IList<StaffDto> Data { get; set; }
    }
    public class CreateStaffRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public IList<int> UserRoles { get; set; } = new List<int>();
    }
}

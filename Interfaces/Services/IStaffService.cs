using ApplicationIdentity.DTOs;
using ApplicationIdentity.Entities;
using ApplicationIdentity2.DTOs;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Services
{
    public interface IStaffService
    {
        BaseResponse AddStaff(CreateStaffRequest request);
        BaseResponse UpdateStaff(int id, Staff staff);
        bool DeleteStaff(int id);
        StaffResponseModel GetStaff(int id);
        StaffsResponseModel GetStaffs();
    }
}

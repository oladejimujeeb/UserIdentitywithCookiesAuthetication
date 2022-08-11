using ApplicationIdentity.Entities;
using System.Collections.Generic;

namespace ApplicationIdentity.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Staff AddStaff(Staff staff);
        Staff UpdateStaff(Staff staff);
        bool DeleteStaff(Staff staff);
        Staff GetStaff(int id);
        IList<Staff> GetStaffs();
    }
}

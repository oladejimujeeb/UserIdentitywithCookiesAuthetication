using ApplicationIdentity.Context;
using ApplicationIdentity.Entities;
using ApplicationIdentity.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace ApplicationIdentity.Implementations.Repositories
{
    public class StaffRepository : IStaffRepository
    {
        private readonly ApplicationContext _context;
        public StaffRepository(ApplicationContext context)
        {
            _context = context;
        }
        public Staff AddStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            _context.SaveChanges();
            return staff;
        }

        public bool DeleteStaff(Staff staff)
        {
            _context.Staffs.Remove(staff);
            _context.SaveChanges();
            return true;
        }

        public Staff GetStaff(int id)
        {
            var staff = _context.Staffs.Where(x => x.Id == id).SingleOrDefault();
            return staff;
        }

        public IList<Staff> GetStaffs()
        {
            var staffs = _context.Staffs.ToList();
            return staffs;
        }

        public Staff UpdateStaff(Staff staff)
        {
            _context.Staffs.Update(staff);
            _context.SaveChanges();
            return staff;
        }
    }
}

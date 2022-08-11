using ApplicationIdentity.DTOs;
using ApplicationIdentity.Entities;
using ApplicationIdentity.Identity;
using ApplicationIdentity.Interfaces.Identity;
using ApplicationIdentity.Interfaces.Repositories;
using ApplicationIdentity.Interfaces.Services;
using ApplicationIdentity2.DTOs;
using System;

namespace ApplicationIdentity.Implementations.Services
{
    public class StaffService : IStaffService
    {
        private readonly IStaffRepository _staffRepository;
        private readonly IUserRepository _userRepository;
        private readonly IIdentityService _identityService;
        private readonly IRoleRepository _roleRepository;
        
        public StaffService(IStaffRepository staffRepository, IUserRepository userRepository, IIdentityService identityService, IRoleRepository roleRepository)
        {
            _staffRepository = staffRepository;
            _userRepository = userRepository;
            _identityService = identityService;
            _roleRepository = roleRepository;
        }

        public BaseResponse AddStaff(CreateStaffRequest request)
        {
            var authenticatedUser = int.Parse(_identityService.GetUserIdentity());
            var user = new User
            {
                UserName = request.Email,
                Password = request.Password,
                CreatedBy = authenticatedUser
            };
            _userRepository.AddUser(user);
            var roles = _roleRepository.GetSelectedRoles(request.UserRoles);
            foreach(var role in roles)
            {
                var userRole = new UserRole
                {
                    UserId = user.Id,
                    User = user,
                    RoleId = role.Id,
                    Role = role,
                    CreatedBy = authenticatedUser
                };
                user.UserRoles.Add(userRole);
            }
            _userRepository.UpdateUser(user);
            var staff = new Staff
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                PhoneNumber = request.PhoneNumber,
                CreatedBy = authenticatedUser,
                StaffNumber = $"SP{Guid.NewGuid().ToString().Substring(0, 5)}",
                UserId = user.Id
            };
            _staffRepository.AddStaff(staff);
           
            return new BaseResponse
            {
                Status = true,
                Message = "Succesfully added"
            };
        }

        public bool DeleteStaff(int id)
        {
            throw new System.NotImplementedException();
        }

        public StaffResponseModel GetStaff(int id)
        {
            throw new System.NotImplementedException();
        }

        public StaffsResponseModel GetStaffs()
        {
            throw new System.NotImplementedException();
        }

        public BaseResponse UpdateStaff(int id, Staff staff)
        {
            throw new System.NotImplementedException();
        }
    }
}

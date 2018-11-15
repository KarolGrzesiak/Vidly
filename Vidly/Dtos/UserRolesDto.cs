using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Vidly.Dtos
{
    public class UserRolesDto
    {
        [Key]
        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class ExpandedUserDto
    {
        [Key]
        [Display(Name = "Username")]
        public string Username { get; set; }

        public string Email { get; set; }
        public string Password { get; set; }
        [Display(Name = "Lockout End Date Utc")]
        public DateTime? LockoutEndDateUtc { get; set; }

        public int AccessFailedCount { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<UserRolesDto> Roles { get; set; }

        public string Phone { get; set; }
        [Display(Name = "Driving License")]
        public string DrivingLicense { get; set; }

    }

    public class UserRoleDto
    {
        [Key]
        public string Username { get; set; }

        [Display(Name = "Role Name")]
        public string RoleName { get; set; }
    }

    public class RoleDto
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Role Name")]

        public string RoleName { get; set; }

    }

    public class UserAndRolesDto
    {
        [Key]
        public string Username { get; set; }

        public List<UserRoleDto> colUserRoleDto { get; set; }

    }





}
using System.ComponentModel.DataAnnotations;

namespace APIPrototype.Models
{
    public class Mas_User
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string PasswordHash { get; set; }
    }

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }

    public class Mas_UserRole
    {
        [Key]
        [Required]
        public string RoleID { get; set; } = null!;
        public string? RoleName { get; set; }
    }

    public class Mas_UserRoleAssign
    {
        [Required]
        public string RoleID { get; set; } = null!;

        [Required]
        public string UserID { get; set; } = null!;

        public int? Active { get; set; }

        public DateTime? LastUpdate { get; set; }
    }

    public class Mas_UserRoleAuthor
    {
        [Required]
        public string RoleID { get; set; } = null!;

        [Required]
        public string ModuleID { get; set; } = null!;

        [Required]
        public string MenuID { get; set; } = null!;

        public string? Author { get; set; }
    }
}

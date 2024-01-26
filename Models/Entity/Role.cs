using System.ComponentModel.DataAnnotations;

namespace ApiPhoneEcommerce.Models.Entity
{
    public class Role
    {
        [Key]
        [StringLength(450)]
        public string Id { get; set; } = null!;

        [StringLength(50)]
        public string? UserName { get; set; }

        [StringLength(50)]
        public string? RoleName { get; set; } = "user";
    }
}

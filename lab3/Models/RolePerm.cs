using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    public class RolePerm
    {
        public int PermsId { get; set; }
        public int RolesId { get; set; }

        [ForeignKey("RolesId")]
        public Role Role { get; set; } = null!;

        [ForeignKey("PermsId")]
        public Perm Perm { get; set; } = null!;
    }
}

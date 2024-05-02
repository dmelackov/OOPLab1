namespace lab3.Models
{
    public class RolePerm
    {
        public int RoleId { get; set; }
        public int PermId { get; set; }

        public Role Role { get; set; } = null!;
        public Perm Perm { get; set; } = null!;
    }
}

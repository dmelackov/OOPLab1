namespace lab3.Models
{
    public class WorkspaceProfile
    {
        public int Id { get; set; }
        public int ProfileId { get; set; }
        public int WorkspaceId { get; set; }
        public int RoleId { get; set; }

        public Profile Profile { get; set; } = null!;
        public Workspace Workspace { get; set; } = null!;
        public Role Role { get; set; } = null!;
    }
}

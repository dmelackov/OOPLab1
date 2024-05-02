namespace lab3.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public List<WorkspaceProfile> WorkspaceProfiles { get; set; } = new List<WorkspaceProfile>();
        public List<Workspace> CreatedWorkspaces { get; set; } = new List<Workspace>();
    }
}

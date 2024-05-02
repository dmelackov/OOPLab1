using System.ComponentModel.DataAnnotations.Schema;

namespace lab3.Models
{
    public class Workspace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CreatorId {  get; set; }

        public List<WorkspaceProfile> WorkspaceProfiles { get; set; } = new List<WorkspaceProfile>();
        public Profile Creator { get; set; } = null!;
    }
}

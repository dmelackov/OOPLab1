namespace lab3.Models
{
    public class Perm
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Role> Roles { get; set; } = new List<Role>();
    }
}

namespace lab3.Models
{
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<Perm> Perms { get; set;} = new List<Perm>();
    }
}

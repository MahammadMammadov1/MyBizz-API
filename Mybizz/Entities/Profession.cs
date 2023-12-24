namespace Mybizz.Entities
{
    public class Profession : BaseEntity
    {
        public string  Name { get; set; }
        public List<Member> Members { get; set; }
    }
}

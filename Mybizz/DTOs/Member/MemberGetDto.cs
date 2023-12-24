namespace Mybizz.DTOs.Member
{
    public class MemberGetDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public string Desc { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}

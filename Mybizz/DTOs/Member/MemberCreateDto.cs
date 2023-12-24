using System.ComponentModel.DataAnnotations.Schema;

namespace Mybizz.DTOs.Member
{
    public class MemberCreateDto
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }
        public string Desc { get; set; }
        public string InstaUrl { get; set; }
        public string FaceUrl { get; set; }
        public string TwitUrl { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
    }
}

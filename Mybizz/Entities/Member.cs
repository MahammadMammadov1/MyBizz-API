using System.ComponentModel.DataAnnotations.Schema;

namespace Mybizz.Entities
{
    public class Member : BaseEntity
    {
        public string FullName { get; set; }
        public int ProfessionId { get; set; }   
        public Profession Profession { get; set; }
        public string Desc { get; set; }    
        public string InstaUrl{ get; set; }
        public string FaceUrl{ get; set; }
        public string TwitUrl{ get; set; }
        public string ImagePath { get; set; }
    }
}

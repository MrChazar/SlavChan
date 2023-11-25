using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Subject
    {
        [Required]
        [Key]
        public int Id { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required]
        [StringLength(450)]
        public string Content { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public float TimeSinceLastPost { get; set; }

        public string? SubjectImage { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Board Board { get; set; }

        public int BoardId {  get; set; }

        public ICollection<Reply> Replies { get; set; }

    }
}

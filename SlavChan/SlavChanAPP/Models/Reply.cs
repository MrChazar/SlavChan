using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Reply
    {
        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public Guid? ReplyUserId { get; set; }

        [Required]
        [StringLength(400)]
        public string Content { get; set; }

        [Required]
        public int SubjectId { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        public DateTime ReplyDate { get; set; }

        public string? ReplyImage { get; set; }

    }
}

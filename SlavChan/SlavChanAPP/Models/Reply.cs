using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Reply
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ReplyUserId { get; set; }

        [Required]
        [StringLength(400)]
        public string Content { get; set; }


        public byte[]? Image { get; set; }

        [Required]
        public Guid SubjectId { get; set; }

        [Required]
        public Subject Subject { get; set; }

        [Required]
        public DateTime ReplyDate { get; set; }

    }
}

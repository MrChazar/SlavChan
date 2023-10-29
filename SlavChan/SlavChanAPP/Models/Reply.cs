using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Reply
    {
        [Required]
        [Key]
        public Guid ReplyId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ReplyUserId { get; set; }

        [Required]
        [StringLength(400)]
        public string Content { get; set; }


        public byte[]? Image { get; set; }

        public Guid ThreadId { get; set; }

        public Thread Thread { get; set; }
    }
}

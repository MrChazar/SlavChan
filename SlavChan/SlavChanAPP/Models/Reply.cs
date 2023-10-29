using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Reply
    {
        [Required]
        public Guid Guid { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid ReplyUserId { get; set; }

        [Required]
        [StringLength(400)]
        public string Content { get; set; }


        public byte[]? Image { get; set; }
    }
}

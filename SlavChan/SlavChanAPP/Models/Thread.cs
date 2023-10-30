using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Thread
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [StringLength(450)]
        public string Content { get; set; }

        [Required]
        public DateTime PostDate { get; set; }

        [Required]
        public float TimeSinceLastPost { get; set; }

        public byte[]? Image { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Board Board { get; set; }

        public int BoardId {  get; set; }

        public ICollection<Reply> Replies { get; set; }

    }
}

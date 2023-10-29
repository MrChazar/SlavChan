using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Thread
    {
        [Required]
        public Guid ThreadID { get; set; }
        
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
        public DateTime TimeSinceLastPost { get; set; }

        [Required]
        public byte[] Image { get; set; }

        [Required]
        public Guid UserId { get; set; }
    }
}

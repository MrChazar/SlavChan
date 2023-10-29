using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Board
    {
        [Required]
        [StringLength(3)]
        public string Shortcuts { get; set; }
        
        [Required]
        public string Name { get; set; }
    }
}

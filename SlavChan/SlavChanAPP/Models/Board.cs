using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SlavChanAPP.Models
{
    public class Board
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(3)]
        public string Shortcut { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        public ICollection<Thread> Threads { get; set;}
    }
}

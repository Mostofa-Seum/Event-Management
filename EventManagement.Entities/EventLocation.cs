using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Entities
{
    [Table("EventLocation")]
    public class EventLocation
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(250)]
        public string Title { get; set; } = null!;
        [Required]
        public string Address { get; set; } = null!;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public int UpdatedBy { get; set; }
        public bool IsActive { get; set; } = true;
    }
}

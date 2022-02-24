using System.ComponentModel.DataAnnotations;

namespace PremierLeague
{
    public class Club
    {
        [Key]
        public int ClubId { get; set; }
        [Required]
        [StringLength(30)]
        public string ClubName { get; set;} = string.Empty;
        [Required]
        [StringLength(50)]
        public string City { get; set; } = string.Empty;

        public int PlayerId { get; set; }
        public Player Player { get; set; } = null!;

    }
}

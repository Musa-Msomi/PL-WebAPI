using System.ComponentModel.DataAnnotations;

namespace PremierLeague
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required]  
        public string FirstName { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        public DateTime? BirthDate { get; set; }    
        

        [Required]
        public string Position { get; set; } = string.Empty; 

        [Required]
        public int JerseyNumber { get; set; }

        public string ClubName { get; set; } = string.Empty;

        //public Club Club { get; set; } = null!;
    }
}

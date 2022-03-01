using System.ComponentModel.DataAnnotations;

namespace PremierLeague
{
    public class Player
    {
        [Key]
        public int PlayerId { get; set; }
        [Required(ErrorMessage ="Name is required")]  
        public string FirstName { get; set; } = string.Empty;
        [Required(ErrorMessage = "Last name is required")]
        public string LastName { get; set; } = string.Empty;
        [Required(ErrorMessage ="Date is required. Please enter date in format YYYY-MM-DD")]
        public DateTime? BirthDate { get; set; }    
        

        [Required(ErrorMessage ="Player position is required")]
        public string Position { get; set; } = string.Empty; 

        [Required(ErrorMessage ="Please enter positive numeric digit")]
        public uint JerseyNumber { get; set; }

        [Required(ErrorMessage ="Club name is required")]
        public string ClubName { get; set; } = string.Empty;

        //public Club Club { get; set; } = null!;
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ClientId { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Prenume")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [DisplayName("Nume (de familie)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [DisplayName("Adresa de e-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data nașterii")]
        public DateTime BirthDate { get; set; }

        public ICollection<Subscription>? Subscriptions { get; set; }

    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data activării")]
        public DateTime Started { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data expirării")]
        public DateTime Expires { get; set; }

        [Required]
        [DisplayName("Client (email)")]
        public int ClientId { get; set; }
        public Client? Client { get; set; }

        [Required]
        [DisplayName("Filiala (adresa)")]
        public int BranchId { get; set; }

        [DisplayName("Filiala (adresa)")]
        public Branch? Branch { get; set; }

    }
}

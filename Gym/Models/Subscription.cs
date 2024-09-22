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

        public int ClientId { get; set; }
        public Client? Client { get; set; }

        public int BranchId { get; set; }
        public Branch? Branch { get; set; }

    }
}

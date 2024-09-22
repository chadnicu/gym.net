using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Gym.Models
{
    public class Branch
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BranchId { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("Oraș")]
        public string City { get; set; }

        [Required]
        [StringLength(200)]
        [DisplayName("Adresă")]
        public string Address { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data fondării")]
        public DateTime Founded { get; set; }
        public ICollection<Equipment>? Equipments { get; set; }
        public ICollection<Subscription>? Subscriptions { get; set; }

    }
}

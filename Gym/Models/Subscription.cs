using NuGet.Packaging.Signing;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Subscription
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data activării")]
        public DateTime Started { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data expirării")]
        public DateTime Expires { get; set; }
        //public ICollection<Client> Clients { get; set; }
        //public ICollection<Branch> Branches { get; set; }
    }
}

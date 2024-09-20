using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Branch
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
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
    }
}

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Gym.Models
{
    public class Equipment
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Required]  
        [StringLength(100, MinimumLength = 2)]
        [DisplayName("Denumire")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [DisplayName("Brand")]
        public string Brand { get; set; }

        [Required]
        [StringLength(100)]
        [DisplayName("Grupa de muschi antrenată")]
        public string MuscleGroup { get; set; }

        [Required]
        [Range(0.01, 10000)]
        [DisplayName("Preț")]
        public float Price { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayName("Data procurării")]
        public DateTime PurchasedAt { get; set; }

        // public ICollection<Branch> Branches { get; set; }
    }
}

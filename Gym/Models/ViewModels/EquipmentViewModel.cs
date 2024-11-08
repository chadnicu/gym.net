using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gym.Models.ViewModels
{
    public class EquipmentViewModel
    {
        public int EquipmentId { get; set; }
            public string Name { get; set; }
            public string Brand { get; set; }

        [Display(Name="Muscle Group")]
            public string MuscleGroup { get; set; }
            public string Price { get; set; }
        
        [Display(Name="Purchased At")]
        public string PurchasedAt { get; set; }
       
        [Display(Name = "Branch's Address")]
        public string Address { get; set; }

            public EquipmentViewModel(Equipment equipment)
            {
            EquipmentId = equipment.EquipmentId;
                Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(equipment.Name.ToLower());
                Brand = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(equipment.Brand.ToLower());
                MuscleGroup = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(equipment.MuscleGroup.ToLower());
                Price = equipment.Price.ToString("C");
                PurchasedAt = equipment.PurchasedAt.ToString("MM/dd/yyyy");
                Address = equipment.Branch.Address;
            }

    }
}

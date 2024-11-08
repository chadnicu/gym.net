using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gym.Models.ViewModels
{
    public class BranchViewModel
    {
        public int BranchId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }

        [Display(Name = "Founded at")]
        public string Founded { get; set; }

        public BranchViewModel(Branch branch)
        {
            BranchId = branch.BranchId;
            City = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(branch.City.ToLower());
            Address= CultureInfo.CurrentCulture.TextInfo.ToTitleCase(branch.Address.ToLower());
            Founded = branch.Founded.ToString("MM/dd/yyyy");
        }
    }
}

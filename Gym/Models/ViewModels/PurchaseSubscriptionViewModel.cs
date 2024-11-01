using System.ComponentModel.DataAnnotations;
using Gym.Validations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gym.Models.ViewModels
{
    public class PurchaseSubscriptionViewModel
    {
        public PurchaseSubscriptionViewModel()
        {
           Branches = new List<Branch>();
           AvailableDurations = new List<int>();
           BirthDate = DateTime.Today.AddYears(-18);
        }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Prenume")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 2)]
        [Display(Name = "Nume (de familie)")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Adresa de e-mail")]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Data nașterii")]
        [MinAge(16, ErrorMessage = "Trebuie să ai cel puțin 16 ani.")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Please select a branch")]
        [Display(Name = "Branch")]
        public int BranchId { get; set; }

        [Required(ErrorMessage = "Please select subscription duration")]
        [Display(Name = "Duration (months)")]
        public int Duration { get; set; }

        public int? ClientId { get; set; }

        [BindNever]
        public IEnumerable<Branch> Branches { get; set; }

        [BindNever]
        public IEnumerable<int> AvailableDurations { get; set; }
    }
} 
using System.ComponentModel.DataAnnotations;

namespace Gym.Models.ViewModels
{
    public class SubscriptionViewModel
    {        
        public int SubscriptionId { get; set; }

        [Display(Name = "Purchased At")]
        public string Started { get; set; }

        [Display(Name = "Expires At")]
        public string Expires { get; set; }

        [Display(Name ="Client's Email")]
        public string ClientEmail { get; set; }

        [Display(Name ="Branch's Address")]
        public string BranchAddress { get; set; }
        
        public SubscriptionViewModel(Subscription subscription)
        {
            SubscriptionId = subscription.SubscriptionId;
            Started = subscription.Started.ToString("MM/dd/yyyy");
            Expires = subscription.Expires.ToString("MM/dd/yyyy");
            ClientEmail = subscription.Client?.Email ?? "N/A";
            BranchAddress = subscription.Branch?.Address ?? "N/A";
        }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Gym.Models.ViewModels
{
    public class ClientViewModel
    {
            public int ClientId { get; set; }

        [Display(Name = "First Name")]
            public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Email Address")]
        public string Email { get; set; }

        [Display(Name = "Date of birth")]
        public string BirthDate { get; set; }

            public ClientViewModel(Client client)
            {
                ClientId = client.ClientId;
                FirstName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.FirstName.ToLower());
                LastName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(client.LastName.ToLower());
                Email = client.Email;
                BirthDate = client.BirthDate.ToString("MM/dd/yyyy");
        }
    }
}

namespace Gym.Models.ViewModels
{
    public class PaginationViewModel
    {
        public IEnumerable<EquipmentViewModel> EquipmentViewModel { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}

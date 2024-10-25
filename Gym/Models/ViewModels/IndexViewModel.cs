namespace Gym.Models.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Equipment> Equipment { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterViewModel FilterViewModel { get; set; }
        public SortViewModel SortViewModel { get; set; }
    }
}

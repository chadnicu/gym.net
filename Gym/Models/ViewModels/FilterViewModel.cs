using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gym.Models.ViewModels
{
    public class FilterViewModel
    {
        public FilterViewModel(List<Branch> branches, int? branch, string name)
        {
            Branches = new SelectList(branches, "BranchId", "Address", branch);
            SelectedBranch = branch;
            SelectedName = name;
        }
        public SelectList Branches { get; private set; }
        public int? SelectedBranch { get; private set; }
        public string SelectedName { get; private set; }
    }
}

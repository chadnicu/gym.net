namespace Gym.Models.ViewModels
{
    public class SortViewModel
    {
        public SortOption Current { get; private set; }
        public SortOption NameSort { get; private set; }
        public SortOption BrandSort { get; private set; }
        public SortOption PriceSort { get; private set; }
        public SortOption PurchasedAtSort { get; private set; }
        public SortOption BranchSort { get; private set; }

        public SortViewModel(SortOption sortOrder)
        {
            Current = sortOrder;
            NameSort = sortOrder == SortOption.NameAsc ? SortOption.NameDesc : SortOption.NameAsc;
            BrandSort = sortOrder == SortOption.BrandAsc ? SortOption.BrandDesc : SortOption.BrandAsc;
            PriceSort = sortOrder == SortOption.PriceAsc ? SortOption.PriceDesc : SortOption.PriceAsc;
            PurchasedAtSort = sortOrder == SortOption.PurchasedAtAsc ? SortOption.PurchasedAtDesc : SortOption.PurchasedAtAsc;
            BranchSort = sortOrder == SortOption.BranchAsc ? SortOption.BranchDesc : SortOption.BranchAsc;
        }
    }

      public enum SortOption
    {
        NameAsc,
        NameDesc,
        BrandAsc,
        BrandDesc,
        PriceAsc,
        PriceDesc,
        PurchasedAtAsc,
        PurchasedAtDesc,
        BranchAsc,
        BranchDesc
    }
}

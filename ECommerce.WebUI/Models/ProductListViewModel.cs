using ECommerce.Entities.Models;

namespace ECommerce.WebUI.Models
{
    public class ProductListViewModel
    {
        public List<Product>? Products { get; set; }
        public int CurrentCategory { get; set; }
        public int PageCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }


        public bool hasSortingClicked { get; set; }
        public bool hasDescSortingClicked { get; set; }
        public bool hasSortingPrice { get; set; }
        public bool hasSortingPriceClicked { get; set; }
        public bool hasDescSortingPrice { get; set; }
    }
}
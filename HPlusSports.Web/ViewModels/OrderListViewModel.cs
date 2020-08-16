using System.Collections.Generic;

namespace HPlusSports.Web.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<OrderListItemViewModel> Orders { get; set; }
    }
}

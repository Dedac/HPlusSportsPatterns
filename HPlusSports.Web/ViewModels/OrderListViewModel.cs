using System.Collections.Generic;

namespace HPlusSports.Web.ViewModels
{
    public class OrderListViewModel
    {
        public IEnumerable<IOrderListItemViewModel> Orders { get; set; }
    }
}

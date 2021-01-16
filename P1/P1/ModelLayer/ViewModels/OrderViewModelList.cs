using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class OrderViewModelList
    {
        public List<OrderViewModel> orderViewModelsList {get;set;}
        public OrderViewModelList()
        {

        }
        public void SetOrderViewModelList(List<OrderViewModel> or)
        {
            orderViewModelsList = or;
        }

    }

}

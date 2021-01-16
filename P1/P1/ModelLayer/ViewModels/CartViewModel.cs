using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CartViewModel
    {
        public string guitar { get; set; }
        [Display(Name = "Qty.")]
        public int guitarQty { get; set; }
        [Display(Name = "Guitar Price")]
        public double GuitarPrice = 999.99;
        public string strings { get; set; }
        public int stringsQty { get; set; }
        public double stringPrice = 9.95;
        public string Case { get; set; }
        public int CaseQty { get; set; }
        public double CasePrice = 59.95;
        public string amplifier { get; set; }
        public int amplifierQty { get; set; }
        public double amplifierPrice = 299.95;
        public double totalPrice { get; set; }

        public CartViewModel()
        {

        }
        public double GetTotalPrice()
        {
            return totalPrice;
        }
    }
}

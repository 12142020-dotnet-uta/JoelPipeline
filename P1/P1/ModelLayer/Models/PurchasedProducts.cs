using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class PurchasedProducts
    {
        [Key]
        public Guid PurchaseId { get; set; } = Guid.NewGuid();
        public Guid OrderId { get; set; }
        public Guid productId { get; set; }


        public PurchasedProducts(Guid OrId, Guid PrId)
        {
            this.OrderId = OrId;
            this.productId = PrId;
        }
        public PurchasedProducts()
        {

        }
        /// <summary>
        /// returns a productId for a purchasedProduct
        /// </summary>
        /// <returns></returns>
        // public Guid GetProductId()
        // {
        //     return productId;
        // }

    }
}

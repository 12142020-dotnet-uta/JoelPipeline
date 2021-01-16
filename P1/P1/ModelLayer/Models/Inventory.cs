using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModelLayer
{
    public class Inventory
    {
        [Key]
        public Guid invKey { get; set; } = Guid.NewGuid();
        public Guid storeId { get; set; }
        public Guid productId { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="stId"></param>
        /// <param name="prId"></param>
        /// <param name="qt"></param>
        /// <param name="price"></param>
        public Inventory(Guid stId, Guid prId, int qt, double price)
        {
            this.storeId = stId;
            this.productId = prId;
            this.quantity = qt;
            this.price = price;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public Inventory()
        {

        }
        /// <summary>
        /// decrements the quantity of the inventory by 1
        /// </summary>
        public void decrementInventory()
        {
            this.quantity -= 1;
        }
        /// <summary>
        /// sets the storId Guid to the Guid passed into the method
        /// </summary>
        /// <param name="stId"></param>
        public void SetStoreId(Guid stId)
        {
            storeId = stId;
        }
        /// <summary>
        /// sets the productId to the productId Guid that is passed into the method
        /// </summary>
        /// <param name="prId"></param>
        public void SetProductId(Guid prId)
        {
            productId = prId;
        }
        /// <summary>
        /// increments the qauntity of the inventory by 1
        /// </summary>
        public void incrementInventory()
        {
            this.quantity += 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer
{
    public class Product
    {
        [Key]
        public Guid ProductId { get; set; } = Guid.NewGuid();
        public string productName { get; set; }
        public double productPrice { get; set; }
        public string productDescription { get; set; }

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="productName"></param>
        /// <param name="productPrice"></param>
        /// <param name="productDescription"></param>
        public Product(string productName, double productPrice, string productDescription)
        {
            this.productName = productName;
            this.productPrice = productPrice;
            this.productDescription = productDescription;
        }
        /// <summary>
        /// empty constructor
        /// </summary>
        public Product()
        {

        }
    }
}

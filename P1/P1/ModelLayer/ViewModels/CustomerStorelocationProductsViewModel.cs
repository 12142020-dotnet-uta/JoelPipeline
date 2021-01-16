using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class CustomerStorelocationProductsViewModel
    {
        public Customer customer { get; set; }
        public StoreLocation storeLocation { get; set; }
        public List<Inventory> inventory { get; set; }
        public List<Product> products { get; set; }
        
        public int quantityToAddToCart { get; set; }
        
        public string VMproductName { get; set; }
        public int numOfGuitars { get; set; }
        public int numOfAmplifiers { get; set; }
        public int numOfStrings { get; set; }
        public int numOfCases { get; set; }
        public Guid customerId { get; set; }
        public Guid storeId { get; set; }
        public string defaultStore { get; set; } = null;



        public CustomerStorelocationProductsViewModel(Customer cust, StoreLocation local, List<Inventory> inv, List<Product> pr, int qty, string productName)
        {
            customer = cust;
            storeLocation = local;
            inventory = inv;
            products = pr;
            quantityToAddToCart = qty;
            this.VMproductName = productName;

        }
        public CustomerStorelocationProductsViewModel()
        {

        }
        public void SetNumOfGuitars(int num)
        {
            numOfGuitars = num;
        }
        public void SetNumOfAmplifiers(int num)
        {
            numOfAmplifiers = num;
        }
        public void SetNumOfStrings(int num)
        {
            numOfStrings = num;
        }
        public void SetNumOfCases(int num)
        {
            numOfCases = num;
        }
        public void SetCustomerId(Guid id)
        {
            customerId = id;
        }
        public void SetStoreId(Guid id)
        {
            storeId = id;
        }
    }

    
}

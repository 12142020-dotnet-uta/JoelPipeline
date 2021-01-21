using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelLayer;
using ModelLayer.ViewModels;

namespace RepositoryLayer
{
    public class Repository : IStatistic
    {
        private GwDbContext DbContext;
        DbSet<Customer> customers;
        DbSet<Product> products;
        DbSet<StoreLocation> storeLocations;
        DbSet<Inventory> allInventory;
        DbSet<PurchasedProducts> purchasedProducts;
        DbSet<Order> orderHistory;
        public Repository(GwDbContext gwDbContext)
        {
            DbContext = gwDbContext;
            this.customers = DbContext.customers;
            this.products = DbContext.products;
            this.storeLocations = DbContext.storeLocations;
            this.allInventory = DbContext.allInventory;
            this.purchasedProducts = DbContext.purchasedProducts;
            this.orderHistory = DbContext.orderHistory;
        }

        //static GwDbContext DbContext = new GwDbContext();
        //DbSet<Customer> customers = DbContext.customers;
        //static DbSet<Product> products = DbContext.products;
        //static DbSet<Order> orderHistory = DbContext.orderHistory;
        //static DbSet<StoreLocation> storeLocations = DbContext.storeLocations;
        //static DbSet<Inventory> allInventory = DbContext.allInventory;
        //static DbSet<PurchasedProducts> purchasedProducts = DbContext.purchasedProducts;
        

        public List<Customer> GetAllCustomers()
        {
            return customers.ToList();
        }

        //static List<Customer> customers = new List<Customer>();
        //static List<Product> products = new List<Product>();
        //static List<Order> orderHistory = new List<Order>();
        //static List<StoreLocation> storeLocations = new List<StoreLocation>();
        //static List<Inventory> allInventory = new List<Inventory>();

        //static Functions fs = new Functions();


        public Repository()
        {

        }
        //public Repository(GwDbContext context)
        //{
        //    Repository.DbContext = context;
        //}
        public void Save()
        {
            DbContext.SaveChanges();
        }

        int loginC = 0;
        string fName;
        string lName;
        /// <summary>
        /// validaies uniqeness and create customer and adds the customer to the customer List
        /// </summary>
        public Customer LoginOrCreateCustomer(int loginChoice)
        {
            loginC = loginChoice;
            bool customerCreationBool = false;
            Customer c1 = new Customer();
            if (loginChoice == 2)
            {
                // do
                // {
                Console.WriteLine("Enter your information and we will create a new account for you.");
                Console.Write("Pleas enter your first name: ");
                fName = Console.ReadLine();
                Console.Write("Pleas enter your last name: ");
                lName = Console.ReadLine();
                Console.WriteLine($"\nHello {fName} {lName}! Enjoy your shopping experience!\n");

                Customer c = customers.Where(x => x.firstName == fName && x.lastName == lName).FirstOrDefault();
                if (c == null)
                {
                    c1 = new Customer(fName, lName);
                    customers.Add(c1);
                    DbContext.SaveChanges();
                    return c1;
                }
                else if (c != null)
                {
                    customerCreationBool = true;
                    return c;
                }

                //customerCreationBool = true;
                //
            }
            else if (loginChoice == 1)
            {
                Customer validatedCustomer = ValidateUserExists();

                return validatedCustomer;
            }
            return null;
        }

        public List<Order> getOrdersByStoreId(Guid storeId)
        {
                List<Order> p = new List<Order>();

                foreach (var item in orderHistory)
                {
                    if (item.StoreId == storeId)
                    {
                        p.Add(item);
                    }
                }

                //Console.WriteLine($"---there are {p.Count} orders in the history");
                return p.ToList();
        }

        public List<Order> getAllOrders()
        {

            return orderHistory.ToList();
        }

        //todo if bool is true logic
        /// <summary>
        /// Returns a list of all products
        /// </summary>
        /// <returns></returns>    
        public List<Product> GetProducts()
        {
            
            List<Product> p = new List<Product>();

            foreach (var item in products)
            {

                p.Add(item);

            }
            return p.ToList();

        }

        public Customer GetCustById(Guid customerId)
        {
            Customer customer = new Customer();
            foreach(var item in customers)
            {
                if (item.CustomerId == customerId)
                {
                    customer = item;
                }
            }
            return customer; 
        }

        /// <summary>
        /// return 1 product where the string property productName == the string passed into the method
        /// </summary>
        /// <param name="prName"></param>
        /// <returns></returns>
        public Product GetProductByName(string prName)
        {
            Product p = new Product();
            foreach (var item in products)
            {
                if (item.productName == prName)
                {
                    p = item;
                }
            }
            return p;
        }
        /// <summary>
        /// adds an order to the total orderHistory list
        /// </summary>
        /// <param name="item"></param>
        public void AddOrderToHistory(Order item)
        {
            orderHistory.Add(item);
            DbContext.SaveChanges();
            Console.WriteLine(orderHistory.Count());
        }
        /// <summary>
        /// returns all of the order histories of the customer passed into the method
        /// </summary>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<Order> GetOrderHistory(Customer customer)
        {
            //Console.WriteLine(customer.firstName);
            List<Order> p = new List<Order>();

            foreach (var item in orderHistory)
            {
                if (item.CustomerId == customer.CustomerId)
                {
                    p.Add(item);
                }
            }

            //Console.WriteLine($"---there are {p.Count} orders in the history");
            return p.ToList();

        }
        /// <summary>
        /// Returns a StoreLocation by the string matching the locaitonName
        /// </summary>
        /// <param name="locationName"></param>
        /// <returns></returns>        
        public StoreLocation GetStoreLocationsByName(string locationName)
        {


            foreach (var item in storeLocations)
            {
                if (item.location == locationName)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// returns the storeLocation object of the storeId that is passed into the method
        /// </summary>
        /// <param name="storeId"></param>
        /// <returns></returns>
        public StoreLocation GetStoreLocationsStringById(Guid storeId)
        {


            foreach (var item in storeLocations)
            {
                if (item.StoreId == storeId)
                {
                    return item;
                }
            }
            return null;
        }
        /// <summary>
        /// return a list of all StoreLocations
        /// </summary>
        /// <returns></returns>
        public List<StoreLocation> GetStoreLocations()
        {

            List<StoreLocation> p = new List<StoreLocation>();
            foreach (var item in storeLocations)
            {
                p.Add(item);
            }
            return p;
        }
        /// <summary>
        /// returns a list of all invetntory items
        /// </summary>
        /// <returns></returns>
        public List<Inventory> GetAllInventory()
        {
            //List<Inventory> p = new List<Inventory>();
            //foreach (var item in allInventory)
            //{
            //    p.Add(item);
            //}
            return allInventory.ToList();
        }

        public void SetDefaultStoreByCustId(Guid customerId, string defaultStore)
        {
            Customer cust = GetCustById(customerId);
            cust.defaultStore = defaultStore;
            DbContext.SaveChanges();
        }

        /// <summary>
        /// a method to seed the database with porducts, StoerLocations, and Inventories
        /// </summary>
        public void PopulateProducts()
        {
            Product p1 = new Product("Guitar", 999.99, "Fender");
            products.Add(p1);
            DbContext.SaveChanges();
            Product p2 = new Product("Case", 59.95, "hard case");
            products.Add(p2);
            DbContext.SaveChanges();
            Product p3 = new Product("Amplifier", 299.95, "Marshall");
            products.Add(p3);
            DbContext.SaveChanges();
            Product p4 = new Product("Strings", 9.95, "D'Aderio");
            products.Add(p4);
            DbContext.SaveChanges();



            //populate store locations
            StoreLocation danaPoint = new StoreLocation("Dana Point");
            storeLocations.Add(danaPoint);
            DbContext.SaveChanges();
            StoreLocation Irvine = new StoreLocation("Irvine");
            storeLocations.Add(Irvine);
            DbContext.SaveChanges();
            StoreLocation HuntingtonBeach = new StoreLocation("Huntington Beach");
            storeLocations.Add(HuntingtonBeach);
            DbContext.SaveChanges();
            Console.WriteLine($"--after populating the storeLocations table there are {storeLocations.Count()} store locations");

            //populating Dana Point inventories
            Inventory DanaPointInventory1 = new Inventory(danaPoint.StoreId, p1.ProductId, 10, p1.productPrice);
            allInventory.Add(DanaPointInventory1);
            DbContext.SaveChanges();
            Inventory DanaPointInventory2 = new Inventory(danaPoint.StoreId, p2.ProductId, 10, p2.productPrice);
            allInventory.Add(DanaPointInventory2);
            DbContext.SaveChanges();
            Inventory DanaPointInventory3 = new Inventory(danaPoint.StoreId, p3.ProductId, 10, p3.productPrice);
            allInventory.Add(DanaPointInventory3);
            DbContext.SaveChanges();
            Inventory DanaPointInventory4 = new Inventory(danaPoint.StoreId, p4.ProductId, 50, p4.productPrice);
            allInventory.Add(DanaPointInventory4);
            DbContext.SaveChanges();

            //populatin Irvine inventories
            Inventory IrvineInventory1 = new Inventory(Irvine.StoreId, p1.ProductId, 10, p1.productPrice);
            allInventory.Add(IrvineInventory1);
            DbContext.SaveChanges();
            Inventory IrvineInventory2 = new Inventory(Irvine.StoreId, p2.ProductId, 10, p2.productPrice);
            allInventory.Add(IrvineInventory2);
            DbContext.SaveChanges();
            Inventory IrvineInventory3 = new Inventory(Irvine.StoreId, p3.ProductId, 10, p3.productPrice);
            allInventory.Add(IrvineInventory3);
            DbContext.SaveChanges();
            Inventory IrvineInventory4 = new Inventory(Irvine.StoreId, p4.ProductId, 50, p4.productPrice);
            allInventory.Add(IrvineInventory4);
            DbContext.SaveChanges();

            //populatin Huntington Beach inventories
            Inventory HuntingtonBeachInventory1 = new Inventory(HuntingtonBeach.StoreId, p1.ProductId, 10, p1.productPrice);
            allInventory.Add(HuntingtonBeachInventory1);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory2 = new Inventory(HuntingtonBeach.StoreId, p2.ProductId, 10, p2.productPrice);
            allInventory.Add(HuntingtonBeachInventory2);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory3 = new Inventory(HuntingtonBeach.StoreId, p3.ProductId, 10, p3.productPrice);
            allInventory.Add(HuntingtonBeachInventory3);
            DbContext.SaveChanges();
            Inventory HuntingtonBeachInventory4 = new Inventory(HuntingtonBeach.StoreId, p4.ProductId, 50, p4.productPrice);
            allInventory.Add(HuntingtonBeachInventory4);
            DbContext.SaveChanges();


            // foreach (var item in products)
            // {
            //     Console.WriteLine($"all 4 product ids are {item.ProductId}");
            // }

            // Console.WriteLine($"There are {allInventory.Count} total inventories");
            // foreach (var item in allInventory)
            // {
            //     Console.WriteLine($"all of the inventory productIds are {item.productId}");
            // }
            // foreach (var item in allInventory)
            // {
            //     Console.WriteLine(item.storeId);
            // }
        }

        public void DecrementInventory(Inventory x)
        {
            //Inventory inventory = allInventory.Where(item => item.invKey == x.invKey);
            x.decrementInventory();
            DbContext.SaveChanges();
        }

        /// <summary>
        /// returns an int of the quantity in the Iventory of the storeId and the product passed into the method
        /// </summary>
        /// <param name="stId"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        internal int GetSecificInventoryQuantity(Guid stId, Product x)
        {
            List<Inventory> StoreIventroy = new List<Inventory>();

            foreach (var item in allInventory)
            {
                if (item.storeId == stId)
                {
                    StoreIventroy.Add(item);

                }
            }

            //Console.WriteLine($"the x productId is {x.ProductId}");
            foreach (var item in StoreIventroy)
            {
                // Console.WriteLine($"the inventory product id is {item.productId}");
                // Console.WriteLine($"the x product id is {x.ProductId}");
                if (x.ProductId == item.productId)
                {
                    Inventory currentInventory = item;
                    int i = item.quantity;
                    return i;
                }

            }
            return -1;
        }
        /// <summary>
        /// this prints all of the inventory quantities
        /// </summary>
        public void PrintAllInvTotals()
        {
            foreach (var item in allInventory)
            {
                Console.WriteLine(item.quantity);
            }
        }
        /// <summary>
        /// this returns a specific Inventory with the storeId and productId that are passed into the method
        /// </summary>
        /// <param name="stId"></param>
        /// <param name="prId"></param>
        /// <returns></returns>
        public Inventory GetInventoryByStIdPrId(Guid stId, Guid prId)
        {
            Inventory i = new Inventory();
            foreach (var item in allInventory)
            {
                if (item.storeId == stId && item.productId == prId)
                {
                    i = item;

                }

            }
            return i;
        }
        /// <summary>
        /// returns a list of all of the products for the order id that is passed into the method
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<Product> GetProductsFromOrder(Guid orderId)
        {
            //Console.WriteLine("---this is just inside of the GetProducts() method");
            List<PurchasedProducts> pur = new List<PurchasedProducts>();

            foreach (var item in purchasedProducts)
            {
                if (item.OrderId == orderId)
                {
                    pur.Add(item);
                }

            }
            List<Product> p = new List<Product>();
            foreach (var item in pur)
            {
                try
                {
                    Product prod = GetProductByProdId(item.productId);
                    p.Add(prod);
                }
                catch (System.NullReferenceException e)
                {

                    Console.WriteLine("product is null", e);
                }

            }
            return p.ToList();
        }

        /// <summary>
        /// prints the contents of the orderid that is passed into the method and then prints the product names,
        ///  descriptions, and prices and total cost of the order
        /// </summary>
        /// <param name="orderId"></param>
        public void PrintOrder(Guid orderId)
        {

            double total = 0;
            Console.WriteLine($"\nThis is your order:\n");

            List<Product> prodList = GetProductsFromOrder(orderId);


            foreach (var item in prodList)
            {

                Console.WriteLine($"{item.productName}-{item.productDescription}  {item.productPrice}");
                total += item.productPrice;
            }

            Order thisOrder = GetOrderById(orderId);

            Console.Write($"Date: {thisOrder.dateTime}. Total = ");
            Console.WriteLine(total.ToString("0,0.00", CultureInfo.InvariantCulture));
        }
        /// <summary>
        /// returns the product by the productId passed into the method
        /// </summary>
        /// <param name="prId"></param>
        /// <returns></returns>
        public Product GetProductByProdId(Guid prId)
        {
            foreach (var item in products)
            {
                if (item.ProductId == prId)
                {
                    return item;
                }
            }
            return null;
        }

        public Order GetOrderById(Guid orId)
        {
            foreach (var item in orderHistory)
            {
                if (item.OrderId == orId)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Order> GetOrderListByCustId(Guid custId)
        {
            List<Order> orderList = new List<Order>();
            foreach (var item in orderHistory)
            {
                if (item.OrderId == custId)
                {
                   orderList.Add(item);
                }
            }
            return orderList; ;
        }
        public void AddPurchasedProduct(PurchasedProducts pp)
        {
            purchasedProducts.Add(pp);
            DbContext.SaveChanges();
        }

        public List<PurchasedProducts> GetAllPurchasedProducts()
        {
            List<PurchasedProducts> pp = new List<PurchasedProducts>();
            foreach (var item in purchasedProducts)
            {
                pp.Add(item);
            }
            return pp;
        }

        /// <summary>
        /// this calculates the percentage each product is purchased per order and prints the result
        /// </summary>
        public StatisticsViewModel PercentageOfProductsPurchasedPerOrder()
        {
            //Product p = new Product();
            //string Guitar = "Guitar";
            int guitarCount = 0;
            //string Case = "Case";
            int caseCount = 0;
            //string Amplifier = "Amplifier";
            int amplifierCount = 0;
            //string Strings = "Striings";
            int stringsCount = 0;
            List<PurchasedProducts> PP = GetAllPurchasedProducts();
            foreach (var item in PP)
            {
                Guid prId = item.productId;
                foreach (var item2 in products)
                {
                    if (prId == item2.ProductId)
                    {
                        if (item2.productName == "Guitar")
                        {
                            guitarCount += 1;
                        }
                        else if (item2.productName == "Case")
                        {
                            caseCount += 1;
                        }
                        else if (item2.productName == "Amplifier")
                        {
                            amplifierCount += 1;
                        }
                        else if (item2.productName == "Strings")
                        {
                            stringsCount += 1;
                        }
                    }
                }
            }
            int total = guitarCount + caseCount + amplifierCount + stringsCount;
            int GuitarP = (guitarCount * 100) / total;
            int CaseP = (caseCount * 100) / total;
            int AmplifierP = (amplifierCount * 100) / total;
            int StringsP = (stringsCount * 100) / total;
            StatisticsViewModel model = new StatisticsViewModel();
            model.GuitarP = GuitarP;
            model.CaseP = CaseP;
            model.AmplifierP = AmplifierP;
            model.StringsP = StringsP;
           


            return model;
        }
        /// <summary>
        /// this suggests the customer buy strings if he has bought a guitar in his or her history
        /// </summary>
        public void SuggestAProductBaseOnHistory(Guid custId)
        {
            Product guitar = new Product();
            foreach (var item in products)
            {
                if (item.productName == "Guitar")
                {
                    guitar = item;
                }
            }
            List<Order> custOrderList = new List<Order>();
            foreach (var item in orderHistory)
            {
                if (item.CustomerId == custId)
                {
                    custOrderList.Add(item);
                }
            }
            List<Inventory> GuitarInventory = new List<Inventory>();
            foreach (var item in allInventory)
            {
                if (item.productId == guitar.ProductId)
                {
                    GuitarInventory.Add(item);
                }
            }
            bool hasBoughGuitar = false;
            foreach (var item in custOrderList)
            {
                Order order = item;
                foreach (var item2 in GuitarInventory)
                {
                    if (order.OrderId == item2.productId)
                    {
                        hasBoughGuitar = true;
                    }
                }
            }
            if (hasBoughGuitar == true)
            {
                Console.WriteLine("Suggested pruchase: Strings for the guitar you previously bought");
            }

        }

        public Customer ValidateUserExists()
        {
            Customer c3 = new Customer();
            bool foundCust = false;
            do
            {
                Console.WriteLine("Please enter correct login information");
                Console.Write("Pleas enter your first name: ");
                string fName = Console.ReadLine();
                Console.Write("Pleas enter your last name: ");
                string lName = Console.ReadLine();
                bool isAdmin = IsAdmin(fName, lName);
                if (isAdmin == true)
                {
                    int choice = 2;
                    do
                    {
                        //choice = fs.AdminMenu();
                        if (choice == 1)
                        {
                            Console.WriteLine("\nEnter the first name of the individual to search for\n");
                            string f = Console.ReadLine();
                            Console.WriteLine("\nEnter the last name of the individual to search for\n");
                            string l = Console.ReadLine();
                            Customer customer = GetCustByName(f, l);
                            PrintCustHistoreyByCustomerObj(customer);
                            foreach (var item in customers)
                            {
                                if (item.firstName == f && item.lastName == l)
                                {
                                    c3 = item;
                                    foundCust = true;

                                }
                            }
                        }
                        else if (choice == 2)
                        {
                            PercentageOfProductsPurchasedPerOrder();

                        }
                    } while (choice != 3);


                    // }
                    //  
                    // {

                }
                foreach (var item in customers)
                {
                    if (item.firstName == fName && item.lastName == lName)
                    {
                        c3 = item;
                        foundCust = true;
                    }
                }



            } while (foundCust == false);
            return c3;
        }
        static List<Order> OrderHistory = new List<Order>();

        public Customer GetCustByName(string f, string l)
        {
            Customer c1 = new Customer();
            foreach (var item in customers)
            {
                if (item.firstName == f && item.lastName == l)
                {
                    c1 = item;
                    //foundCust = true;
                }
            }
            return c1;
        }


        public void PrintCustHistoreyByCustomerObj(Customer customer)
        {
            OrderHistory = GetOrderHistory(customer);
            //Console.WriteLine($"OrderHistorey list has {OrderHistory.Count} in it");
            Console.WriteLine($"Your complete purchase history is:");
            if (OrderHistory.Count == 0)
            {
                Console.WriteLine("you have no purchase history");
            }
            //List<Order> thisLocationOderAndCustHistory = new List<Order>();
            foreach (var item in OrderHistory)
            {
                Guid stGuidFromOrder = item.GetStoreIdGuid();
                StoreLocation loc = GetStoreLocationsStringById(stGuidFromOrder);
                string locationString = loc.location;
                Console.WriteLine($"At the {locationString} location ");
                PrintOrder(item.OrderId);
            }
        }
        /// <summary>
        /// returns a boolean true if login is Adim Admin
        /// </summary>
        /// <param name="f"></param>
        /// <param name="l"></param>
        /// <returns></returns>
        public Boolean IsAdmin(string f, string l)
        {
            if ((f == "Admin") && (l == "Admin"))
            {
                return true;
            }
            else
                return false;
        }

        //public void CheckForDataAndPopulateIfEmpty()
        //{
        //    if (products.Count == 0)
        //    {
        //        PopulateProducts();
        //    }
        //}
        public Customer ValidateUserExists(string fName, string lName)
        {

            Customer cust = customers.FirstOrDefault(x => x.firstName == fName && x.lastName == lName);
            if(cust == null)
            {
                return null;
            }
            //foreach (var item in customers)
            //{
            //    if (item.firstName == fName && item.lastName == lName)
            //    {
                    
            //        Customer validCustomer = validCustomer = item;// validCustomer.Where(x => x.firstName == fName && lastName == lName);
            //        cust = validCustomer
            //    }
            //}
            return cust;
        }

        public Customer CreateNewOrLoginIfExistsRS(string fName, string lName)
        {
            Customer c1 = new Customer();
            Customer c = customers.Where(x => x.firstName == fName && x.lastName == lName).FirstOrDefault();
            if (c == null)
            {
                c1 = new Customer(fName, lName);
                customers.Add(c1);
                DbContext.SaveChanges();
                return c1;
            }
            else if (c != null)
            {
                return c;
            }
            return null;
        }
        public double GetProductPrice(string name)
        {
            Product p = GetProductByName(name);
            double price = p.productPrice;
            return price;
        }
        
        /// <summary>
        /// updates the deafualt store of a customer and takesin the customer and the location string of the new store
        /// </summary>
        /// <param name="cust"></param>
        /// <param name="newStore"></param>
        public void updateCustDefaultStore(Customer cust, string newStore)
        {
            cust.defaultStore = newStore;
            DbContext.SaveChanges();
        }
    }//end of class
}//end of namespace

using System;
using System.Collections.Generic;
using ModelLayer;
using RepositoryLayer;
using ModelLayer.ViewModels;
using System.Linq;

namespace BusinessLogicLayer
{
    public class BusinessLogicClass
    {
        private readonly Repository rs;
        public BusinessLogicClass(Repository repository)
        {
            rs = repository;
        }
        public BusinessLogicClass() { }

        //GwDbContext DbContext = new GwDbContext();
        //static Repository rs = new Repository();
        //CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel = new ModelLayer.ViewModels.CustomerStorelocationProductsViewModel();
        static Customer loggedInCustBLC = new Customer();
        //static List<Inventory> currentStoreInventory = new List<Inventory>();
        static StoreLocation currentStore = new StoreLocation();
        // List<Product> allProducts = rs.GetProducts();
        static List<Product> currentCartProducts = new List<Product>();
        //static List<Customer> allCustomers = rs.GetAllCustomers();
        //static List<PurchasedProducts> purchasedProducts1 = rs.GetAllPurchasedProducts();
        public void PopulateDb()
        {
            rs.PopulateProducts();
        }

        public CustomerStorelocationProductsViewModel SetNumOfProductsAndIds(CustomerStorelocationProductsViewModel c)
        {
            List<Inventory> currentStoreInventory = GetInventoryByStoreId(currentStore.StoreId);
            //List<Inventory> currentStoreInventory = rs.GetInventoryByStIdPrI();
            List<Product> allProducts = rs.GetProducts();
            foreach (var item in allProducts)
            {
                if(item.productName == "Guitar")
                {
                    foreach(var x in currentStoreInventory)
                    {
                        if(x.productId == item.ProductId)
                        {
                            c.SetNumOfGuitars(x.quantity);
                        }
                    }
                }
                if (item.productName == "Amplifier")
                {
                    foreach (var x in currentStoreInventory)
                    {
                        if (x.productId == item.ProductId)
                        {
                            c.SetNumOfAmplifiers(x.quantity);
                        }
                    }
                }
                if (item.productName == "Strings")
                {
                    foreach (var x in currentStoreInventory)
                    {
                        if (x.productId == item.ProductId)
                        {
                            c.SetNumOfStrings(x.quantity);
                        }
                    }
                }
                if (item.productName == "Case")
                {
                    foreach (var x in currentStoreInventory)
                    {
                        if (x.productId == item.ProductId)
                        {
                            c.SetNumOfCases(x.quantity);
                        }
                    }
                }

            }
            try
            {
                c.SetCustomerId(loggedInCustBLC.CustomerId);
            }
            catch(Exception e) {  }
            c.SetStoreId(currentStore.StoreId);
            return c;
        }

        public OrderViewModelList GetOrdersByStoreLocationName(string storeLocationName)
        {
            StoreLocation store = rs.GetStoreLocationsByName(storeLocationName);
            List<Order> orderlist = rs.getOrdersByStoreId(store.StoreId);

            OrderViewModelList OVML = GetOrderViewModels(orderlist);
            return OVML;
        }

        public AllCustomerNamesViewModel GetCustomerNameList()
        {
            List<Customer> allCist = rs.GetAllCustomers();
            List<string> list = new List<string>();
            AllCustomerNamesViewModel allNames = new AllCustomerNamesViewModel();
            foreach (var item in allCist)
            {
                string names = item.firstName + " " + item.lastName;
                list.Add(names);
            }
            allNames.nameList = list;
            return allNames;
        }
        /// <summary>
        /// makes an order 
        /// ViewModelList based on the list of orders sent in.
        /// </summary>
        /// <param name="orderHist"></param>
        /// <returns></returns>
        public OrderViewModelList GetOrderViewModels(List<Order> orderHist)
        {
            List<Product> allProducts = rs.GetProducts();
            List<OrderViewModel> listToDefineOrderViewModelList = new List<OrderViewModel>();
            List<PurchasedProducts> purchasedProducts1 = rs.GetAllPurchasedProducts();
            foreach ( var item in orderHist)
            {
                Customer cust = rs.GetCustById(item.CustomerId);
                
                OrderViewModel model = new OrderViewModel();
                model.cusomerName = cust.firstName + " " + cust.lastName;
                //string Fname = GetCustById(item.CustomerId).firstName;
                //string Lname = GetCustById(item.CustomerId).lastName;
                foreach(var x in purchasedProducts1) //need to regather the purchased products
                {
                    if(x.OrderId == item.OrderId)
                    {
                        foreach(var j in allProducts)
                        {
                            if (x.productId == j.ProductId)
                            {
                               if(j.productName == "Guitar")
                                {
                                    model.SetGuitarName("Guitar");
                                    model.guitarQty += 1;
                                    model.totalPrice += j.productPrice;
                                }
                                if (j.productName == "Case")
                                {
                                    model.SetCaseName("Case");
                                    model.CaseQty += 1;
                                    model.totalPrice += j.productPrice;
                                }
                                if (j.productName == "Amplifier")
                                {
                                    model.SetAmplifierName("Amplifier");
                                    model.amplifierQty += 1;
                                    model.totalPrice += j.productPrice;
                                }
                                if (j.productName == "Strings")
                                {
                                    model.SetStringsName("Strings");
                                    model.stringsQty += 1;
                                    model.totalPrice += j.productPrice;
                                }
                                

                            }
                        }
                           
                    }
                    
                }
                model.SetDateTime(item.dateTime);
                listToDefineOrderViewModelList.Add(model);
            }

            OrderViewModelList list = new OrderViewModelList();
            list.SetOrderViewModelList(listToDefineOrderViewModelList);
            return list;
        }

        public void SetStoreLocation(string defaultstore)
        {
            loggedInCustBLC.defaultStore = defaultstore;
        }

        public List<Order> SearchOrderHistoryByName(string searchString1, string searchString2)
        {
            Customer cust = rs.GetCustByName(searchString1,searchString2);
            //rs.GetOrderHistory(cust);
            List<Order> custHist = rs.GetOrderHistory(cust);
                return custHist;
        }

        public Customer ValidateCust(string firstName, string lastName)
        {
            try { 
                Customer LoggedInCustomer = rs.ValidateUserExists(firstName, lastName);
                loggedInCustBLC = LoggedInCustomer;
                return LoggedInCustomer;
            }
            catch (NullReferenceException e)
            {
                throw;
            }
        }
        public Customer GetLoggedInCustBLC()
        {
            return loggedInCustBLC;
        }



        public Customer CreatNewReturnIfExistsBC(string firstName, string lastName)
        {
            Customer c1 = rs.CreateNewOrLoginIfExistsRS(firstName, lastName);
            loggedInCustBLC = c1;
            return c1;
        }

        public void AddItemsToCart(CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel)
        {
            List<Inventory> currentStoreInventory = GetInventoryByStoreId(currentStore.StoreId);
            List<Product> allProducts = GetAllProducts();
            //List<Product> cartProducts = new List<Product>();
            Inventory productInventory = new Inventory();
            for (int i = 0; i < customerStorelocationProductsViewModel.quantityToAddToCart; i++)
            {
                foreach (var item in allProducts)
                {
                    if(item.productName == customerStorelocationProductsViewModel.VMproductName)
                    {
                        currentCartProducts.Add(item);
                        foreach(var x in currentStoreInventory)
                        {
                            if(x.productId == item.ProductId)
                            {
                                productInventory = x;
                                x.decrementInventory();
                                rs.Save();
                                    
                            }
                        }
                       
                    }
                }
            }
        }

        public void EmptyCart()
        {
            List<Inventory> currentStoreInventory = GetInventoryByStoreId(currentStore.StoreId);
            List<Product> allProducts = GetAllProducts();
            List<Product> cartProducts = new List<Product>();
            Inventory productInventory = new Inventory();
            for (int i = 0; i < currentCartProducts.Count; i++)
            {
                foreach (var item in allProducts)
                {
                    if (item.productName == currentCartProducts[i].productName)
                    {
                        cartProducts.Add(item);
                        foreach (var x in currentStoreInventory)
                        {
                            if (x.productId == item.ProductId)
                            {
                                productInventory = x;
                                x.incrementInventory();
                                rs.Save();

                            }
                        }

                    }
                }
            }
            currentCartProducts = new List<Product>();
        }

        public void PlaceOrder(CustomerStorelocationProductsViewModel c)
        {

            Order newOrder = new Order(loggedInCustBLC.CustomerId, currentStore.StoreId);
            rs.AddOrderToHistory(newOrder);
            rs.Save();
            foreach(var item in currentCartProducts)
            {
                PurchasedProducts purchasedProducts = new PurchasedProducts(newOrder.OrderId, item.ProductId);
                rs.AddPurchasedProduct(purchasedProducts);
                rs.Save();
            }
            currentCartProducts = new List<Product>();
        }



        /// <summary>
        /// takes the current cart items and creates a cart view model
        /// </summary>
        /// <returns></returns>
        public CartViewModel GetCartViewModel()
        {
            CartViewModel cart = new CartViewModel();
            double totalPrice = cart.GetTotalPrice();

            foreach (var item in currentCartProducts)
            {
                string ProductName = item.productName;
                switch (ProductName)
                {
                    case "Guitar":
                        cart.guitar = "Guitar";
                        cart.guitarQty += 1;
                        totalPrice += cart.GuitarPrice;
                        break;
                    case "Case":
                        cart.Case = "Case";
                        cart.CaseQty += 1;
                        totalPrice += cart.CasePrice;
                        break;
                    case "Strings":
                        cart.strings = "Strings";
                        cart.stringsQty += 1;
                        totalPrice += cart.stringPrice;
                        break;
                    case "Amplifier":
                        cart.amplifier = "amplifier";
                        cart.amplifierQty += 1;
                        totalPrice += cart.amplifierPrice;
                        break;
                }
            }
            cart.totalPrice = totalPrice;
            return cart;
    }
        public List<Product> GetCurrentCartProducts()
        {
            return currentCartProducts.ToList();
        }

        /// <summary>
        /// changes the store abreviation to the locationName and gets the store from the repository
        /// </summary>
        string locationName;
        public StoreLocation getStoreLocationByAbreviation(string storeAbreviation)
        {

          StoreLocation storeLocation = rs.GetStoreLocationsByName(storeAbreviation);
            currentStore = storeLocation;
            return storeLocation;
        }
        
        public List<Inventory> GetInventoryByStoreId(Guid StoreId)
        {
            List<Inventory> storeInventory = new List<Inventory>();
            List<Inventory> allIventory = rs.GetAllInventory();
            foreach(var item in allIventory)
            {
                if(item.storeId == StoreId)
                {
                    storeInventory.Add(item);
                }
            }
            //currentStoreInventory = storeInventory;
            return storeInventory;
        }
        public Customer GetCustById(Guid custId)
        {
            return GetCustById(custId);
        }
        /// <summary>
        /// returns a list of all products
        /// </summary>
        /// <returns></returns>
        public List<Product> GetAllProducts()
        {
            
            return rs.GetProducts();
        }
        public StoreLocation GetCurrentStoreLocation()
        {
            return currentStore;
        }
        public StatisticsViewModel GetStatisticsViewModel()
        {
            StatisticsViewModel newMoldel = rs.PercentageOfProductsPurchasedPerOrder();
            return newMoldel;
        }
    }
}

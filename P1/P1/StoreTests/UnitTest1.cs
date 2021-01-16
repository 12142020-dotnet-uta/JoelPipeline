using System;
using System.Collections.Generic;
using ModelLayer;
using Xunit;
using RepositoryLayer;
using BusinessLogicLayer;
using ModelLayer.ViewModels;

namespace StoreTests
{
    public class UnitTest1
    {
        Repository rs = new Repository();
        BusinessLogicClass blc = new BusinessLogicClass();

        
        //[Fact]
        //public void ListOfAllProductsTest()
        //{
        //    List<Product> allProducts = rs.GetProducts();
        //    Assert.Contains(allProducts, item => item.productName=="Guitar");
        //}
        //[Fact]
        //public void getCustomerByNameTest()
        //{
        //    Guid newGuid = Guid.Parse("3B52D838-6014-42AA-934E-52F226C99AAA");
        //    Customer cust = rs.GetCustByName("Jane", "Doe");
        //    Assert.True(cust.CustomerId == newGuid);
        //}
        //[Fact]
        //public void getCustByIdTest()
        //{
        //    Guid newGuid = Guid.Parse("3B52D838-6014-42AA-934E-52F226C99AAA");
        //    Customer cust = rs.GetCustById(newGuid);
        //    Assert.True(cust.firstName == "Jane");
        //}
        //[Fact]
        //public void getStoreByIdTest()
        //{
        //    Guid newGuid = Guid.Parse("1A03050E-4B09-4632-B2AD-6BA5C31C7D16");
        //    StoreLocation store = rs.GetStoreLocationsStringById(newGuid);
        //    Assert.True(store.location == "Irvine");
        //}
        //[Fact]
        //public void getStoreByNameTest()
        //{
        //    Guid newGuid = Guid.Parse("1A03050E-4B09-4632-B2AD-6BA5C31C7D16");
        //    StoreLocation store = rs.GetStoreLocationsByName("Irvine");
        //    Assert.True(store.StoreId == newGuid);
        //}
        //[Fact]
        //public void validateLoginTest()
        //{
        //    Guid newGuid = Guid.Parse("3B52D838-6014-42AA-934E-52F226C99AAA");
        //    Customer cust = blc.ValidateCust("Jane", "Doe");
        //    Assert.True(cust.CustomerId == newGuid);
        //}
        //[Fact]
        //public void GetLoggedInCustTest()
        //{
        //    Customer LoggedInCust = blc.CreatNewReturnIfExistsBC("Jane", "Doe");
        //    Assert.True(LoggedInCust.firstName == "Jane");
        //}
        //[Fact]
        //public void CreateCustomertest()
        //{
        //    Customer cust = new Customer();
        //    Assert.True(cust != null);
        //}
        //[Fact]
        //public void CreateProductTest()
        //{
        //    Product p = new Product();
        //    Assert.True(p != null);
        //}
        //[Fact]
        //public void CreateNewReturnIfExistsTest()
        //{
        //    Customer cust = blc.CreatNewReturnIfExistsBC("Jane", "Doe");
        //    Guid newGuid = Guid.Parse("3B52D838-6014-42AA-934E-52F226C99AAA");
        //    Assert.True(cust.CustomerId == newGuid);
        //}
        //[Fact]
        //public void SetDefaultStoreLocationTest()
        //{
        //    Customer cust = rs.GetCustByName("Jane", "Doe");
        //    cust.defaultStore = "Irvine";
        //    Assert.True(cust.defaultStore == "Irvine");
        //}
        //[Fact]
        //public void SetNumOfStringsTest()
        //{
        //    CustomerStorelocationProductsViewModel c = new CustomerStorelocationProductsViewModel();
        //    c.SetNumOfStrings(3);
        //    Assert.True(c.numOfStrings == 3);
        //}
        //[Fact]
        //public void SetNumOfGuitarsTest()
        //{
        //    CustomerStorelocationProductsViewModel c = new CustomerStorelocationProductsViewModel();
        //    c.SetNumOfGuitars(3);
        //    Assert.True(c.numOfGuitars == 3);
        //}
        //[Fact]
        //public void SetNumOfAmplifiersTest()
        //{
        //    CustomerStorelocationProductsViewModel c = new CustomerStorelocationProductsViewModel();
        //    c.SetNumOfAmplifiers(3);
        //    Assert.True(c.numOfAmplifiers == 3);
        //}
        //[Fact]
        //public void SetNumOfCasesTest()
        //{
        //    CustomerStorelocationProductsViewModel c = new CustomerStorelocationProductsViewModel();
        //    c.SetNumOfCases(3);
        //    Assert.True(c.numOfCases == 3);
        //}
        //[Fact]
        //public void GetCurrentStoreLocationTest()
        //{
        //    StoreLocation CurrentStore = rs.GetStoreLocationsByName("Irvine");
        //    Assert.True(CurrentStore.location == "Irvine");
        //}
        //[Fact]
        //public void GetAllCustTest()
        //{
        //    List<Customer> allCust = rs.GetAllCustomers();
        //    Assert.Contains(allCust, item => item.firstName == "Jane");
        //}
        //[Fact]
        //public void GetAllStoresTest()
        //{
        //    List<StoreLocation> stores = rs.GetStoreLocations();
        //    Assert.Contains(stores, store => store.location == "Dana Point");
        //}
        //[Fact]
        //public void GetAllInventoryTest()
        //{
        //    List<Inventory> inventories = rs.GetAllInventory();
        //    Assert.Contains(inventories, x => x.price == 999.99);
        //}
        //[Fact]
        //public void searchOrderHistByNameTest()
        //{
        //    Guid newGuid = Guid.Parse("DBCB6749-A9E8-4799-8030-9008F6E0B3BB");
        //    List<Order> orderHist = blc.SearchOrderHistoryByName("Jane", "Doe");
        //    Assert.Contains(orderHist, item => item.StoreId == newGuid);
        //}
        ////[Fact]
        ////public void GetCartViewModel()
        ////{
        ////    List<Product> currentCartProducts = new List<Product>();
        ////    Product p = rs.GetProductByName("Guitar");
        ////    Product x = rs.GetProductByName("Amplifier");
        ////    currentCartProducts.Add(p);
        ////    currentCartProducts.Add(x);
        ////    CartViewModel cart = blc.GetCartViewModel();
        ////    Assert.True(cart.amplifierQty == 1);
        ////}
    }
}

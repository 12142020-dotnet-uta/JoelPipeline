using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using BusinessLogicLayer;
using ModelLayer.ViewModels;

namespace P1_JoelBarnum.Controllers
{
    public class StoreLocationController : Controller
    {
         
        BusinessLogicClass blc = new BusinessLogicClass();
        // GET: StoreLocationController
        public ActionResult Choice(string LocationAbreviation)
        {

            Customer cust = blc.GetLoggedInCustBLC();
            StoreLocation stLocation = blc.getStoreLocationByAbreviation(LocationAbreviation);
            List<Inventory> inv = blc.GetInventoryByStoreId(stLocation.StoreId);
            List<Product> pro = blc.GetAllProducts();
            int qty = 0;
            string VMproductName = "";
            var customerStorelocationProductsViewModel = new CustomerStorelocationProductsViewModel(cust, stLocation, inv, pro, qty, VMproductName);
            customerStorelocationProductsViewModel = blc.SetNumOfProductsAndIds(customerStorelocationProductsViewModel);

            return View("StoreLocation2", customerStorelocationProductsViewModel);
            // return View();
        }
        public ActionResult AddToCart(CustomerStorelocationProductsViewModel customerStorelocationProductsViewModel)
        {
            if(customerStorelocationProductsViewModel.VMproductName == "Guitar")
            {
                if(customerStorelocationProductsViewModel.quantityToAddToCart > customerStorelocationProductsViewModel.numOfGuitars ||
                    customerStorelocationProductsViewModel.quantityToAddToCart !=1)
                {
                    string location = blc.GetCurrentStoreLocation().location;
                    // ModelState.AddModelError("Failure", "You can only buy 1 of that items at a timer");
                    return RedirectToAction("Choice", new { LocationAbreviation = location });
                }

            }
            if (customerStorelocationProductsViewModel.VMproductName == "Amplifier")
            {
                if (customerStorelocationProductsViewModel.quantityToAddToCart > customerStorelocationProductsViewModel.numOfAmplifiers ||
                    customerStorelocationProductsViewModel.quantityToAddToCart != 1)
                {
                    string location = blc.GetCurrentStoreLocation().location;
                    // ModelState.AddModelError("Failure", "You can only buy 1 of that items at a timer");
                    return RedirectToAction("Choice", new { LocationAbreviation = location });
                }

            }
            if (customerStorelocationProductsViewModel.VMproductName == "Case")
            {
                if (customerStorelocationProductsViewModel.quantityToAddToCart > customerStorelocationProductsViewModel.numOfCases ||
                    customerStorelocationProductsViewModel.quantityToAddToCart != 1)
                {
                    string location = blc.GetCurrentStoreLocation().location;
                    // ModelState.AddModelError("Failure", "You can only buy 1 of that items at a timer");
                    return RedirectToAction("Choice", new { LocationAbreviation = location });
                }

            }
            if (customerStorelocationProductsViewModel.VMproductName == "Strings")
            {
                if (customerStorelocationProductsViewModel.quantityToAddToCart > customerStorelocationProductsViewModel.numOfStrings)
                {
                    string location = blc.GetCurrentStoreLocation().location;
                    // ModelState.AddModelError("Failure", "You can only buy 1 of that items at a timer");
                    return RedirectToAction("Choice", new { LocationAbreviation = location });
                }

            }

            blc.SetStoreLocation(customerStorelocationProductsViewModel.defaultStore);
            blc.AddItemsToCart(customerStorelocationProductsViewModel);
            StoreLocation local = blc.GetCurrentStoreLocation();
            string locationString = local.location;
            return Choice( locationString);
            
            
        }
        public ActionResult GetCart(int id, string defaultstore)
        {
            CartViewModel cartViewModel = blc.GetCartViewModel();
            
            return View("DisplayCart", cartViewModel);
        }
        
        public ActionResult ContinueShopping()
        {
            string x = blc.GetCurrentStoreLocation().location;
            return Choice(x);
        }
        public ActionResult LogOut()
        {
            List<Product> cart = blc.GetCurrentCartProducts();
            if(cart.Count > 0)
            {
                blc.EmptyCart();
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult CustHistFromStore(string searchString1, string searchString2)
        {
            List<Order> orderHist = blc.SearchOrderHistoryByName(searchString1, searchString2);
            OrderViewModelList orderViewModels = blc.GetOrderViewModels(orderHist);
            return View("CustomerPersonalHistory", orderViewModels);
        }
        // GET: StoreLocationController/Details/5
        public ActionResult PlaceOrder(CustomerStorelocationProductsViewModel c)
        {
            CartViewModel cartViewModel = blc.GetCartViewModel();
            blc.PlaceOrder(c);
            return View("PlaceOrder", cartViewModel);
        }

        // GET: StoreLocationController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StoreLocationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StoreLocationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StoreLocationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

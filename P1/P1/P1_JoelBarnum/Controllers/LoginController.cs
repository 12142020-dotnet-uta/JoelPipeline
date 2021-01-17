using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.ViewModels;
using BusinessLogicLayer;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace P1_JoelBarnum.Controllers
{
    public class LoginController : Controller
    {

        private readonly BusinessLogicClass blc;

        public LoginController(BusinessLogicClass businessLogicClass)
        {
            blc = businessLogicClass;
        }


        //BusinessLogicClass blc = new BusinessLogicClass();
        // GET: Login
        //[ActionName("Login")]
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ValidateCustomerInfo(string firstName, string lastName)
        {
            //System.Diagnostics.Debug.WriteLine($" this is the out put from the form {firstName} {lastName}");
            
               Customer LoggedInCust = blc.ValidateCust(firstName,lastName);
            if(LoggedInCust == null)
            {
                ModelState.AddModelError("Please enter the correct login information", "Please enter the correct login information");
                return RedirectToAction("Login");
            }
            if(LoggedInCust.firstName == "Admin" && LoggedInCust.lastName == "Admin")
            {
                return RedirectToAction("AdminView");
            }
            if(LoggedInCust.defaultStore != null)
            {
                return RedirectToAction("Choice", "StoreLocation",  new { LocationAbreviation = LoggedInCust.defaultStore });
            }
            return View("CreateNew", LoggedInCust);
        }

        public ActionResult AdminView()
        {

            return View();
        }
        [HttpPost]
        public ActionResult SearchByCustName(string searchString1, string searchString2)
        {
            List<Order> orderHist = blc.SearchOrderHistoryByName(searchString1, searchString2);
            OrderViewModelList orderViewModels = blc.GetOrderViewModels(orderHist);
            return View("CustOrderHistoryView", orderViewModels);
        }

        public ActionResult ListAllCustomers()
        {
            AllCustomerNamesViewModel nameList = blc.GetCustomerNameList();
            return View("ListAllCustomers" , nameList);
        }

        public ActionResult ListStoreOrderHistory(string SearchString)
        {
            OrderViewModelList orderViewModelList = blc.GetOrdersByStoreLocationName(SearchString);
            return View("CustOrderHistoryView", orderViewModelList);
        }

        public ActionResult GetStatistics()
        {
            StatisticsViewModel newModel = blc.GetStatisticsViewModel();
            return View("GetStatistics", newModel);
        }
        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            //Customer neCustomer = blc.CreatNewReturnIfExistsBC(firstName, lastName);
            return View();
        }
        public ActionResult CreateNew(string firstName, string lastName)
        {
            Customer neCustomer = blc.CreatNewReturnIfExistsBC(firstName, lastName);
            return View(neCustomer);
        }



        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
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

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
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

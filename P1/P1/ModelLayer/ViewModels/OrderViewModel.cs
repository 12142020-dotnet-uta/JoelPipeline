using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelLayer.ViewModels
{
    public class OrderViewModel
    {
        public Guid OrderId { get; set; }
        public Guid customerId { get; set; }
        public string cusomerName { get; set; }
        public string fisrtName { get; set; }
        public string lastName { get; set; }
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
        public DateTime dateTime { get; set; }

        public void SetCustId(Guid id)
        {
            customerId = id;
        }
        public void SetOrderId(Guid id)
        {
            OrderId = id;
        }
        public void SetCustomerName(string fName)
        {
            cusomerName = fName;
        }
        public void SetDateTime(DateTime dt)
        {
            dateTime = dt;
        }
       public void SetGuitarName(string x)
        {
            guitar = x;
        }
        public void SetCaseName(string x)
        {
            Case = x;
        }
        public void SetAmplifierName(string x)
        {
            amplifier = x;
        }
        public void SetStringsName(string x)
        {
            strings = x;
        }
    }
}

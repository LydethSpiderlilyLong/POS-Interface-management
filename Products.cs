using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS_System_Interface_FinalGroupProject.Model
{
    public class Products
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        public double SellPrice { get; set; }
        public int QtyInStock { get; set; }
        public string Category { get; set; }
        public string Photo { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProductsAPI.Features.Products.Models
{
    public class CreateProductModel
    {
        public string Name { get; set; }
        public string ProductNumber { get; set; }
        public string Color { get; set; }
        public short SafetyStockLevel { get; set; }
        public short ReorderPoint { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime? SellEndDate { get; set; }
        public DateTime? DiscontinuedDate { get; set; }
    }
}
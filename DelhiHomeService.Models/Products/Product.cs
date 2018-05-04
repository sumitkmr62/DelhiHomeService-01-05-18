using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace DelhiHomeService.Models
{
    public class Product
    {
        [DisplayName("Product ID")]
        public int ProductID { get; set; }
        [DisplayName("Name")]
        public string ProductName { get; set; }
        [DisplayName("Description")]
        public string ProductDescription { get; set; }
        [DisplayName("Image")]
        public string ProductImage { get; set; }
    }
}

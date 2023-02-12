using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyEshop.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Display(Name="نام")]
        public string Name { get; set; }
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        public int ItemId { get; set; }

        public Item Item { get; set; }
        public ICollection<CategoryToProduct> CategoryToProducts { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
}

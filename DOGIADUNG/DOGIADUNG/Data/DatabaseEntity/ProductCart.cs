using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using TECH.SharedKernel;

namespace TECH.Data.DatabaseEntity
{
    [Table("ProductCart")]
    public class ProductCart : DomainEntity<int>
    {
        public int? ProductId { get; set; }
        [ForeignKey("product_id")]
        public Products? Products { get; set; }
        public int? CartId { get; set; }
        [ForeignKey("Cart_Id")]
        public Carts? Carts { get; set; }
    }
}

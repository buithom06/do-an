using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TECH.Areas.Admin.Models
{
    public class ProductCartModelView
    {
        public int id { get; set; }
        public int? product_id { get; set; }
        public int? cart_id { get; set; }
    }
}

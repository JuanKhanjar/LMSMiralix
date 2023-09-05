using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.BusinessUseCases.Dtos.GroupProducts
{
    public class GroupProductDto
    {
        public int GroupProductId { get; set; }
        public int GroupId { get; set; }
        public string GroupName { get; set; }
        public int ProductId { get; set; }
        public string ProdcutName { get; set; }
        public decimal Price { get; set; }
        public int AddedQuantity { get; set; }
        public decimal Subtotal { get; set; }
    }

}

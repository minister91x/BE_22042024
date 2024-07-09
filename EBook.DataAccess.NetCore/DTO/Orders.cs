﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EBook.DataAccess.NetCore.DTO
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime CreatedTime { get; set; }
        public string ShipingAddress { get; set; }
        public int TotalAmount { get; set; }
    }

    public class OrdersCreateRequestData
    {
        public int CustomerId { get; set; }
        public string ShipingAddress { get; set; }
        public int TotalAmount { get; set; }
        public List<ProductShopping> products { get; set; }
    }
}

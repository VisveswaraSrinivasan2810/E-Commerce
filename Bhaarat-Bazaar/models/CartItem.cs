﻿using System.ComponentModel.DataAnnotations;

namespace Bhaarat_Bazaar.models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; } 
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }

    }
}

﻿namespace Task2.DTO
{
    public class addCartItemRequestDTO
    {
        public int? CartId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }
    }
}

﻿namespace OnlineShop.Dto
{
    public class ProductDto
    {
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
        public int idProduct { get; set; }
    }
}

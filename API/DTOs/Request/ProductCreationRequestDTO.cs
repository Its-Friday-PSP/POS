﻿using API.Enumerators;
using API.Model;

namespace API.DTOs.Request
{
    public class ProductCreationRequestDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? AmountInStock { get; set; }
        public string? StripeId { get; set; }
        public OriginCountry OriginCountry { get; set; }
        public List<Guid>? Taxes { get; set; }
    }
}

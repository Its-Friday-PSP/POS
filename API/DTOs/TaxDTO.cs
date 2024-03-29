﻿using API.Enumerators;
using API.Model;

namespace API.DTOs
{
    public class TaxDTO
    {
        public Guid Id { get; set; }
        public TaxType Type { get; set; }
        public int? Percentage { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
    }
}

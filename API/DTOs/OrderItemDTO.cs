﻿using System.ComponentModel.DataAnnotations;
namespace API.DTOs
{
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Index { get; set; }
        public int Amount { get; set; }
    }
}
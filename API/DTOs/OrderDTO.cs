﻿using API.Model;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class OrderDTO
    {
        public Guid? Id { get; set; }
        public OrderTypeDTO OrderType { get; set; }
        public decimal? Tip { get; set; }
        public DateTime Date { get; set; }
        public ProductOrderDTO? ProductOrder { get; set; }
        public ServiceOrderDTO? ServiceOrder { get; set; }
    }
}

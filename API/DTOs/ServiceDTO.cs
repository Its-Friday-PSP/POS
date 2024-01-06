﻿using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class ServiceDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public int? DurationInMinutes { get; set; }
        [Required]
        public List<ServiceTimeSlots> serviceTimeSlots { get; set; }
        [Required]
        public Boolean Availability { get; set; }
    }
}

using API.DTOs;
using System.ComponentModel.DataAnnotations;

namespace API.Model
{
    public class Service
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Price Price { get; set; }
        public int DurationInMinutes { get; set; }
        public List<ServiceTimeSlots> ServiceTimeSlots { get; set; }
        public string? StripeId { get; set; }

        public Service(
            Guid id,
            string name,
            string description,
            Price price,
            int durationInMinutes,
            List<ServiceTimeSlots> serviceTimeSlots
        )
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            DurationInMinutes = durationInMinutes;
            ServiceTimeSlots = serviceTimeSlots;
        }

        public Service()
        {
        }

    }

}


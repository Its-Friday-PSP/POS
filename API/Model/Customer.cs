﻿namespace API.Model
{
    public class Customer
    {
        public Guid Id { get; set; }
        public Auth Auth { get; set; }
        public List<Discount> Discounts { get; set; }

        public Customer()
        {

        }
    }
}

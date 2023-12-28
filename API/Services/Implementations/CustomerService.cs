﻿using API.Model;
using API.Repositories.Interfaces;
using API.Services.Interfaces;

namespace API.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer CreateCustomer(Customer customer)
        {
            return _customerRepository.CreateCustomer(customer);
        }

        public Customer DeleteCustomer(Guid customerId)
        {
            return _customerRepository.DeleteCustomer(customerId);
        }

        public Customer GetCustomer(Guid customerId)
        {
            return _customerRepository.GetCustomer(customerId);
        }

        public Customer UpdateCustomer(Guid customerId, Customer customer)
        {
           return _customerRepository.UpdateCustomer(customerId, customer);
        }
    }
}
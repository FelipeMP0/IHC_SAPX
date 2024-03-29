﻿using IHC.Models;
using IHC.Repositories;
using IHC.Repositories.Interfaces;
using IHC.Services.Interfaces;
using System.Collections.Generic;

namespace IHC.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService()
        {
            _customerRepository = new CustomerRepository();
        }
        public Customer Create(Customer customer)
        {
            return _customerRepository.Create(customer);
        }

        public void DeleteById(long id)
        {
            _customerRepository.DeleteById(id);
        }

        public Customer existsWithDocument(string document)
        {
            return _customerRepository.existsWithDocument(document);
        }

        public IEnumerable<Customer> ReadAll(bool active)
        {
            return _customerRepository.ReadAll(active);
        }

        public Customer ReadById(long id)
        {
            return _customerRepository.ReadById(id);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }

        public void ActivateOrDeactivateById(long id, bool active)
        {
            _customerRepository.ActivateOrDeactivateById(id, active);
        }
    }
}

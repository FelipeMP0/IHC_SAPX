using IHC.Models;
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

        public IEnumerable<Customer> ReadAll()
        {
            return _customerRepository.ReadAll();
        }

        public Customer ReadById(long id)
        {
            return _customerRepository.ReadById(id);
        }

        public Customer Update(Customer customer)
        {
            return _customerRepository.Update(customer);
        }
    }
}

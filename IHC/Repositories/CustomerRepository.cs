using IHC.Contexts;
using IHC.Models;
using IHC.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace IHC.Repositories
{
    public class CustomerRepository : ICustomerRepository, IDisposable
    {
        IhcContext Context;

        public CustomerRepository()
        {
            Context = new IhcContext();
        }

        public Customer Create(Customer customer)
        {
            customer = Context.Customers.Add(customer);
            Context.SaveChanges();

            return customer;
        }

        public Customer Update(Customer customer)
        {
            var customerToUpdate = Context.Customers.First(c => c.Id == customer.Id);
            customerToUpdate.Name = customer.Name;
            customerToUpdate.Phone = customer.Phone;
            customerToUpdate.Document = customer.Document;
            customerToUpdate.Email = customer.Email;
            Context.Entry(customerToUpdate).State = EntityState.Modified;
            Context.SaveChanges();

            return customer;
        }

        public void DeleteById(long id)
        {
            var customerToDelete = Context.Customers.First(c => c.Id == id);
            Context.Set<Customer>().Remove(customerToDelete);
            Context.SaveChanges();
        }

        public Customer ReadById(long id)
        {
            return Context.Customers.First(c => c.Id == id);
        }

        public IEnumerable<Customer> ReadAll()
        {
            return Context.Customers.OrderBy(c => c.Id);
        }

        public bool existsWithDocument(string document)
        {
            return Context.Customers.FirstOrDefault(c => c.Document.Trim() == document.Trim()) != null;
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}

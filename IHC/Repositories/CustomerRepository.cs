﻿using IHC.Contexts;
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
            return Context.Customers.FirstOrDefault(c => c.Id == id);
        }

        public IEnumerable<Customer> ReadAll(bool active)
        {
            return Context.Customers.Where(c => c.Active == active).OrderBy(c => c.Id);
        }

        public Customer existsWithDocument(string document)
        {
            return Context.Customers.FirstOrDefault(c => c.Document.Trim() == document.Trim());
        }

        public void Dispose()
        {
            Context.Dispose();
        }

        public void ActivateOrDeactivateById(long id, bool active)
        {
            var customerToUpdate = Context.Customers.First(c => c.Id == id);
            customerToUpdate.Active = active;
            Context.Entry(customerToUpdate).Property(c => c.Active).IsModified = true;
            Context.SaveChanges();
        }
    }
}

using IHC.Models;
using System.Collections.Generic;

namespace IHC.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer Create(Customer customer);
        Customer Update(Customer customer);
        void DeleteById(long id);
        Customer ReadById(long id);
        IEnumerable<Customer> ReadAll();
        bool existsWithDocument(string document);
    }
}

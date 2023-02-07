using Mc2.CrudTest.Presentation.Server.Services;
using Mc2.CrudTest.Shared.Entities;
using System.Collections.Generic;

namespace Mc2.CrudTest.Presentation.Server.Interfaces
{
    public interface ICustomerService
    {
        public IEnumerable<Customer> GetCustomers();

        public Customer GetCustomerById(int id);
        
        public void AddCustomer(Customer customer);

        public void RemoveCustomer(int id);

        public void UpdateCustomer(int id, Customer customer);

    }
}

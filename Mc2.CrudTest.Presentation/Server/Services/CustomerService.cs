using Mc2.CrudTest.Presentation.Server.Interfaces;
using Mc2.CrudTest.Shared.Data;
using Mc2.CrudTest.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mc2.CrudTest.Presentation.Server.Services
{
    public class CustomerService : ICustomerService
    {
        CrudTestContext _context;
        public CustomerService(CrudTestContext context) 
        { 
            _context = context;
        }
        public IEnumerable<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(C => C.CustomerId == id);
            return customer;
        }

        public void AddCustomer(Customer customer)
        {
            var checkExist = IsCustomerExist(customer.Firstname,customer.Lastname,customer.DateOfBirth,customer.Email);  //Check is it any record with same data

            if (!checkExist)
            {
                _context.Customers.Add(customer);
                _context.SaveChanges();
            }
        }

        public void RemoveCustomer(int id) 
        {
            var TargetCustomer = GetCustomerById(id);
            _context.Customers.Remove(TargetCustomer);
            _context.SaveChanges();
        }

        public void UpdateCustomer(int id, Customer customer)
        {
            var checkExist = IsCustomerExistUnion(customer.Firstname, customer.Lastname, customer.DateOfBirth, customer.Email, id);  //Check is it any record with same data

            if(!checkExist)
            {
                var OldCustomer = GetCustomerById(id);
                OldCustomer.CustomerId = customer.CustomerId;
                OldCustomer.Firstname = customer.Firstname;
                OldCustomer.Lastname = customer.Lastname;
                OldCustomer.DateOfBirth = customer.DateOfBirth;
                OldCustomer.PhoneNumber = customer.PhoneNumber;
                OldCustomer.Email = customer.Email;
                OldCustomer.BankAccountNumber = customer.BankAccountNumber;
                _context.Customers.Update(OldCustomer);
                _context.SaveChanges();
            }
        }

        private bool IsCustomerExist(string firstname, string lastname, DateTime dateOfbirh, string email)
        {
            return _context.Customers.Any(C => C.Firstname == firstname || C.Lastname == lastname || C.DateOfBirth == dateOfbirh || C.Email == email);
        }

        private bool IsCustomerExistUnion(string firstname, string lastname, DateTime dateOfbirh, string email, int unionid)
        {
            var unionCustomer = new List<Customer>();
            unionCustomer.Add(GetCustomerById(unionid));

            var existCustomers = _context.Customers.Where((C => C.Firstname == firstname || C.Lastname == lastname || C.DateOfBirth == dateOfbirh || C.Email == email)).ToList();
            var filtered = existCustomers.Except(unionCustomer);

            if(filtered.Count() == 0)
            {
                return false;
            }
            return true;
        }
    }
}

using Azure.Core;
using Azure.Identity;
using CustomerApp.Data;
using CustomerApp.Interface;
using CustomerApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CustomerApp.Service
{
	public class CustomerService : ICustomerService
	{
		private readonly AppData _AppData;

        public CustomerService(AppData Appdata)
        {
            _AppData = Appdata;
        }

		public async Task<List<Customer>> AddCustomer(Customer customer)
		{
			_AppData.Customers.Add(customer);
			await _AppData.SaveChangesAsync();
			return await _AppData.Customers.ToListAsync();
		}

        public async Task<List<Customer>> DeleteCustomer(int id)
        {
            var customer = await _AppData.Customers.FindAsync(id);
            if (customer is null)
                return null;

            _AppData.Customers.Remove(customer);
            await _AppData.SaveChangesAsync();
            return await _AppData.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var cust = await _AppData.Customers.FindAsync(id);
            if (cust is null)
                return null;

            return cust;
        }

        public async Task<List<Customer>> GetCustomers()
		{
			var customer = await _AppData.Customers.ToListAsync();
			return customer;
		}

        public async Task<List<Customer>> UpdateCustomerDeatils(int id, Customer customer)
        {
            var cust = await _AppData.Customers.FindAsync(id);
            if (customer is null)
                return null;

            cust.CustomerName = customer.CustomerName;
            cust.CustomerAddress = customer.CustomerAddress;
            cust.CustomerTelephone = customer.CustomerTelephone;
            cust.ContactPersonName = customer.ContactPersonName;
            cust.ContactPersonEmailAddress = customer.ContactPersonEmailAddress;
            cust.VATNumber = customer.VATNumber;
            await _AppData.SaveChangesAsync();

            return await _AppData.Customers.ToListAsync();
        }
    }
}

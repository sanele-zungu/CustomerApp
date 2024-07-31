using CustomerApp.Models;

namespace CustomerApp.Interface
{
	public interface ICustomerService
	{
		Task<List<Customer>> GetCustomers();
		Task<List<Customer>> AddCustomer(Customer customer);
        Task<Customer> GetCustomer(int id);
        Task<List<Customer>> UpdateCustomerDeatils(int id, Customer customer);
        Task<List<Customer>> DeleteCustomer(int id);
    }
}

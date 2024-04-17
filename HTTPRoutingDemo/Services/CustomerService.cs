using System;
using HTTPRoutingDemo.Database.Models;
using HTTPRoutingDemo.Repositories;

namespace HTTPRoutingDemo.Services
{
	public class CustomerService
	{
		private readonly CustomerRepository _repository;

		public CustomerService(CustomerRepository repository)
		{
			_repository = repository;
		}

		public async Task<Customer?> GetCustomer(int id)
		{
			return await _repository.FindCustomerByIdAsync(id);
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return _repository.GetCustomers();
		}

		public async Task UpdateCustomerAsync(Customer customer)
		{
			await _repository.UpdateCustomerAsync(customer);
		}

		public async Task CreateCustomerAsync(Customer customer)
		{
			await _repository.CreateCustomerAsync(customer);
		}

		public async Task DeleteCustomerAsync(int id)
		{
			await _repository.DeleteCustomerAsync(id);
		}

	}
}


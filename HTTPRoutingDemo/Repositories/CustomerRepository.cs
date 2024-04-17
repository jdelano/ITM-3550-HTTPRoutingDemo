using System;
using HTTPRoutingDemo.Database.Models;

namespace HTTPRoutingDemo.Repositories
{
	public class CustomerRepository
	{

		private readonly CRMContext _context;
		public CustomerRepository(CRMContext context)
		{
			_context = context;
		}

		public IEnumerable<Customer> GetCustomers()
		{
			return _context.Customers.AsEnumerable();
		}

		public async Task<Customer?> FindCustomerByIdAsync(int id)
		{
			return await _context.Customers.FindAsync(id);
		}

		public async Task CreateCustomerAsync(Customer customer)
		{
			await _context.Customers.AddAsync(customer);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteCustomerAsync(int id)
		{
			var customer = await FindCustomerByIdAsync(id);
			if (customer is not null)
			{
				_context.Customers.Remove(customer);
				await _context.SaveChangesAsync();
			}
		}

		public async Task UpdateCustomerAsync(Customer customer)
		{
			var dbCustomer = await FindCustomerByIdAsync(customer.CustomerId);
			if (dbCustomer is not null)
			{
				dbCustomer.FirstName = customer.FirstName;
				dbCustomer.LastName = customer.LastName;
				dbCustomer.Balance = customer.Balance;
				await _context.SaveChangesAsync();
			}
		}

	}
}


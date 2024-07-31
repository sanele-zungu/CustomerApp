using Azure.Core;
using CustomerApp.Interface;
using CustomerApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomerApp.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ICustomerService _customerService;
		public CustomerController(ICustomerService customerservice)
		{
			_customerService = customerservice;
		}
		// GET: CustomerController
		[HttpGet]
		public async Task<ActionResult<List<Customer>>> ListCustomers()
		{
			var result = await _customerService.GetCustomers();
			return View(result);
		}

		// GET: CustomerController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: CustomerController/Create
		[HttpPost]
		public async Task<ActionResult<Customer>>CreateCustomer(Customer customer)
		{
			try
			{
				var result = await _customerService.AddCustomer(customer);
				if(result!=null)
					return RedirectToAction("ListCustomers", "Customer");
				return View(result);
			}
			catch
			{				
				return RedirectToAction("Create", "Customer");
			}
				
						
		}

		// GET: CustomerController/Edit/5
		public async Task<ActionResult<Customer>> Edit(int id)
		{
            var cust = await _customerService.GetCustomer(id);
            if (cust is null)
                return NotFound("This customer does not exist");

			return View(cust);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult<List<Customer>>> Edit(int id, Customer customer)
        {
            try
			{
                var cust = await _customerService.UpdateCustomerDeatils(id, customer);
                if (cust is null)
                    return NotFound("Customer not found");

				
                return RedirectToAction("ListCustomers", "Customer");
            }
			catch
			{
				return View();
			}
		}

		// GET: CustomerController/Delete/5
		public async Task<ActionResult<Customer>> Delete(int id)
		{
            var cust = await _customerService.GetCustomer(id);
            if (cust is null)
                return NotFound("This customer does not exist");

            return View(cust);
        }

		// POST: CustomerController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<ActionResult<Customer>> Delete(int id, Customer customer)
		{
			try
			{
                var cust = await _customerService.DeleteCustomer(id);
                if (cust is null)
                    return NotFound("Customer not found");

                return RedirectToAction("ListCustomers", "Customer");
            }
            catch
			{
				return View();
			}
		}
	}
}

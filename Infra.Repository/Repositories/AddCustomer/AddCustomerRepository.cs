using Domain.Contracts.Repositories.AddCustomer;
using Domain.Entities;

namespace Infra.Repository.Repositories.AddCutomer
{



    public class AddCustomerRepository : IAddCustomerRepository
    {
        private readonly IList<Customer> _customers = new List<Customer>();


        public void AddCustomer(Customer customer)
        {
            _customers.Add(customer);
        }
    }
}
using Domain.Entities;

namespace Domain.Contracts.UseCases.AddCustomer
{
    public interface IAddCustomerUseCases
    {
        void AddCustomer(Customer customer);
    }
}
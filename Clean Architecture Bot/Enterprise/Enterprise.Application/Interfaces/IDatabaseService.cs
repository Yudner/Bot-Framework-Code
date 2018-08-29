using Enterprise.Domain.Customers;
using System.Data.Entity;

namespace Enterprise.Application.Interfaces
{
    public interface IDatabaseService
    {
        IDbSet<Customer> Customers { get; set; }

        void Save();
    }
}
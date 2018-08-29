using Enterprise.Application.Interfaces;
using Enterprise.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enterprise.Persistence
{
    public class DatabaseService : DbContext, IDatabaseService
    {
        public IDbSet<Customer> Customers { get; set; }

        public DatabaseService() : base("Enterprise.Chatbot")
        {
            Database.SetInitializer(new DatabaseInitializer());
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}

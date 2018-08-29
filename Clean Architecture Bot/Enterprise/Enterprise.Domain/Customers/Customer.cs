using Enterprise.Domain.Common;

namespace Enterprise.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email_ { get; set; }
    }
}

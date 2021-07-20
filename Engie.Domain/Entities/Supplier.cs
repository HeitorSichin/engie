using Engie.Shared.Entities;

namespace Engie.Domain.Entities
{
    public class Supplier : Entity
    {
        public Supplier(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
    }
}
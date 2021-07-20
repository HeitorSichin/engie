using System.Collections.Generic;
using Engie.Domain.Entities;

namespace Engie.Domain.Repositories
{
    public interface ISupplierRepository
    {
        Supplier GetSupplier(int id);
        IEnumerable<Supplier> GetSuppliers();
    }
}
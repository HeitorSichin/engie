using System.Collections.Generic;
using System.Linq;
using Engie.Domain.Entities;
using Engie.Domain.Repositories;
using Engie.Infra.Contexts;

namespace Engie.Infra.Repositories
{
    public class SupplierRepository : ISupplierRepository
    {
        private readonly EngieDataContext _context;

        public SupplierRepository(EngieDataContext context)
        {
            _context = context;
        }

        public Supplier GetSupplier(int id)
        {
            return _context.Suppliers.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Supplier> GetSuppliers()
        {
            return _context.Suppliers.OrderBy(x => x.Name);
        }
    }
}
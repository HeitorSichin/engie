using Engie.Infra.Contexts;

namespace Engie.Infra.Transactions
{
    public class Uow : IUow
    {
        private readonly EngieDataContext _context;

        public Uow(EngieDataContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Rollback()
        {

        }
    }
}
using VemDeZap.Infra.Repositories.Base;

namespace VemDeZap.Infra.Transactions
{
    public class UnitOfWork
    {
        private readonly VemDeZapContext _context;

        public UnitOfWork(VemDeZapContext context)
        {
            _context = context;
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}

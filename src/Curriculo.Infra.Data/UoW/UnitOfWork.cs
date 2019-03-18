using Curriculo.Domain.Interfaces;
using Curriculo.Infra.Data.Context;

namespace Curriculo.Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContextSQLS _context;
        public UnitOfWork(ContextSQLS context)
        {
            _context = context;
        }
        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }
    }
}

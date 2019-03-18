using System;
using System.Collections.Generic;
using System.Text;

namespace Curriculo.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        bool Commit();
    }
}

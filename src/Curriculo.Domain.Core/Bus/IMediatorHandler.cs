using Curriculo.Domain.Core.Commands;
using Curriculo.Domain.Core.Events;
using System.Threading.Tasks;

namespace Curriculo.Domain.Core.Bus
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}


namespace Eventos.IO.Domain.Core.Events
{
    public interface IHandler<T> where T : Message
    {
        void Handle(T message);
    }
}

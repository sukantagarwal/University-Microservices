using System.Threading.Tasks;

namespace University.Students.Application
{
    public interface IDomainEventHandler<in T> where T : class
    {
        Task HandleAsync(T @event);
    }
}
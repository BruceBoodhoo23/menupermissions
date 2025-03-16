using System.Threading.Tasks;

namespace MenuPermissions.Interfaces
{
    public interface ICommand
    {
        Task ExecuteAsync();
    }
}


using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IUserRepository: IRepository<TUser>
    {
        Task SaveWithId(TUser user);
    }
}

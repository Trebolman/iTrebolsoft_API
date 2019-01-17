
using System.Linq;

namespace Domain.IRepositories
{
    public interface IBlogRepository:IRepository<TBlog>
    {
        IQueryable<TBlog> FilterBlogs(int pageSize, int page);
    }
}

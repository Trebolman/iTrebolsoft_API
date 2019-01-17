using System.Linq;
namespace Domain.IRepositories
{
    public interface IProductRepository : IRepository<TProducto>
    {
        //IQueryable<TBlog> FilterBlogs(int pageSize, int page);
    }
}

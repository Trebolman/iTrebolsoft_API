using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Persistencia;
namespace Infraestructure.Repositories
{
    public class EFBlogRepository : IBlogRepository
    {
        ItrebolsoftDbContext Context;
        public EFBlogRepository(ItrebolsoftDbContext context)
        {
            Context = context;
        }
        public IQueryable<TBlog> Items => Context.TBlog;

        public void Delete(Guid itemId)
        {
            TBlog dbEntry = Context.TBlog
                .FirstOrDefault(b => b.PublId == itemId);

            if (dbEntry != null)
            {
                Context.TBlog.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public IQueryable<TBlog> FilterBlogs(int pageSize, int page)
        {
            return this.Items
            .Skip((page - 1) * pageSize)
            .Take(pageSize);
        }

        public void Save(TBlog item)
        {
            if (item.PublId == Guid.Empty)
            {
                item.PublId = Guid.NewGuid();
                Context.TBlog.Add(item);
            }
            else
            {
                TBlog dbEntry = Context.TBlog
                .FirstOrDefault(b => b.PublId == item.PublId);
                if (dbEntry != null)
                {
                    dbEntry.PublName = item.PublName;
                    dbEntry.PublBody = item.PublBody;
                    dbEntry.PublDate = item.PublDate;
                    dbEntry.PublDesc = item.PublDesc;
                    dbEntry.TImages = item.TImages;

                }
            }
            Context.SaveChangesAsync();
        }
    }
}

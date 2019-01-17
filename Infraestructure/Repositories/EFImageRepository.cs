using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFImageRepository : IImageRepository
    {
        ItrebolsoftDbContext Context;
        public EFImageRepository(ItrebolsoftDbContext context)
        {
            Context = context;
        }
        public IQueryable<TImages> Items => Context.TImages;

        public void Delete(Guid itemId)
        {
            TImages dbEntry = Context.TImages
                .FirstOrDefault(x => x.ImageId == itemId);

            if (dbEntry != null)
            {
                Context.TImages.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TImages item)
        {
            if (item.ImageId == Guid.Empty)
            {
                item.ImageId = Guid.NewGuid();
                Context.TImages.Add(item);
            }
            else
            {
                TImages dbEntry = Context.TImages
                .FirstOrDefault(x => x.ImageId == item.ImageId);
                if (dbEntry != null)
                {
                    dbEntry.ImageName = item.ImageName;
                    dbEntry.ImageUrl = item.ImageUrl;
                    dbEntry.FkTProductoProdId = item.FkTProductoProdId;
                    dbEntry.FkTBlogPublId = item.FkTBlogPublId;
                    dbEntry.FkTProyProyId = item.FkTProyProyId;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}

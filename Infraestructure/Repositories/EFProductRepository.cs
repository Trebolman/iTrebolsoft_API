using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFProductRepository : IProductRepository
    {
        ItrebolsoftDbContext Context;
        public EFProductRepository(ItrebolsoftDbContext context)
        {
            Context = context;
        }
        public IQueryable<TProducto> Items => Context.TProducto;

        public void Delete(Guid itemId)
        {
            TProducto dbEntry = Context.TProducto
                .FirstOrDefault(x => x.ProdId == itemId);

            if (dbEntry != null)
            {
                Context.TProducto.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TProducto item)
        {
            if (item.ProdId == Guid.Empty)
            {
                item.ProdId = Guid.NewGuid();
                Context.TProducto.Add(item);
            }
            else
            {
                TProducto dbEntry = Context.TProducto
                .FirstOrDefault(x => x.ProdId == item.ProdId);
                if (dbEntry != null)
                {
                    dbEntry.ProdName = item.ProdName;
                    dbEntry.ProdCod = item.ProdCod;
                    dbEntry.ProdDesc = item.ProdDesc;
                    dbEntry.ProdStock = item.ProdStock;
                    dbEntry.ProdBrand = item.ProdBrand;
                    dbEntry.ProdPrice = item.ProdPrice;
                    dbEntry.FkUserUserId = item.FkUserUserId;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}

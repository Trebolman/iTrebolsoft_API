using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Persistencia;

namespace Infraestructure.Repositories
{
    public class EFProyectoRepository : IProyectoRepository
    {
        ItrebolsoftDbContext Context;


        public EFProyectoRepository(ItrebolsoftDbContext context)
        {
            Context = context;
        }
        public IQueryable<TProyectos> Items => Context.TProyectos;
        public void Delete(Guid itemId)
        {
            TProyectos dbEntry = Context.TProyectos
                .FirstOrDefault(x => x.ProyId == itemId);

            if (dbEntry != null)
            {
                Context.TProyectos.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TProyectos item)
        {
            if (item.ProyId == Guid.Empty)
            {
                item.ProyId = Guid.NewGuid();
                Context.TProyectos.Add(item);
            }
            else
            {
                TProyectos dbEntry = Context.TProyectos
                .FirstOrDefault(x => x.ProyId == item.ProyId);
                if (dbEntry != null)
                {
                    dbEntry.ProyTitle = item.ProyTitle;
                    dbEntry.ProyDesc = item.ProyDesc;
                    dbEntry.ProyDate = item.ProyDate;
                    dbEntry.FkTUserUserId = item.FkTUserUserId;
                }
            }
            Context.SaveChangesAsync();
        }
    }
}

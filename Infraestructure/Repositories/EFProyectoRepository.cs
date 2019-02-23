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

        // sacamos los proyectos como consultables
        public IQueryable<TProyectos> Items => Context.TProyectos;

        //metodos de IRepostory
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

        public Guid Save(TProyectos item)
        {
            Guid Id;
            if (item.ProyId == Guid.Empty)
            {
                item.ProyId = Guid.NewGuid();
                Context.TProyectos.Add(item);
                Id = item.ProyId;
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
                    dbEntry.ProyEtiq = item.ProyEtiq;
                    dbEntry.FkTUserUserId = item.FkTUserUserId;
                }
                Id = dbEntry.ProyId;
            }
            Context.SaveChanges();
            return Id;
        }
    }
}

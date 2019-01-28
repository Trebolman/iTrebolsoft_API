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
                    //StringBuilder hex1 = new StringBuilder(dbEntry.RowVersion.Length * 2);
                    //StringBuilder hex2 = new StringBuilder(item.RowVersion.Length * 2);
                    //foreach (byte b in dbEntry.RowVersion)
                    //    hex1.AppendFormat("{0:x2}", b);
                    //var version1 = hex1.ToString();
                    //foreach (byte b in item.RowVersion)
                    //    hex2.AppendFormat("{0:x2}", b);
                    //var version2 = hex2.ToString();
                    //if (version1 == version2)
                    //{
                    //    dbEntry.ProyTitle = item.ProyTitle;
                    //    dbEntry.ProyDesc = item.ProyDesc;
                    //    dbEntry.ProyDate = item.ProyDate;
                    //    dbEntry.FkTUserUserId = item.FkTUserUserId;
                    //}
                    //else
                    //{
                    //    throw new Exception("this entity was modified already, Please retrieve this Entity again.");
                    //}



                    dbEntry.ProyTitle = item.ProyTitle;
                    dbEntry.ProyDesc = item.ProyDesc;
                    dbEntry.ProyDate = item.ProyDate;
                    dbEntry.FkTUserUserId = item.FkTUserUserId;
                }
            }
            Context.SaveChanges();
        }
    }
}

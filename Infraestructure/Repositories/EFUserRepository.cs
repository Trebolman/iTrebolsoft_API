﻿using Domain;
using Domain.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Infraestructure.Persistencia;
using System.Threading.Tasks;

namespace Infraestructure.Repositories
{
    public class EFUserRepository : IUserRepository
    {
        ItrebolsoftDbContext Context;
        public EFUserRepository(ItrebolsoftDbContext context)
        {
            Context = context;
        }
        public IQueryable<TUser> Items => Context.TUser;

        public void Delete(Guid itemId)
        {
            TUser dbEntry = Context.TUser
                .FirstOrDefault(u => u.UserId == itemId);

            if (dbEntry != null)
            {
                Context.TUser.Remove(dbEntry);
                Context.SaveChanges();
            }
        }

        public void Save(TUser item)
        {
            if (item.UserId == Guid.Empty)
            {
                item.UserId = Guid.NewGuid();
                Context.TUser.Add(item);
            }
            else
            {
                TUser dbEntry = Context.TUser
                .FirstOrDefault(u => u.UserId == item.UserId);
                if (dbEntry != null)
                {
                    dbEntry.UserFirstName = item.UserFirstName;
                    dbEntry.UserLastname = item.UserLastname;
                    dbEntry.UserGit = item.UserGit;
                    dbEntry.UserEmail = item.UserEmail;
                    dbEntry.UserAddress = item.UserAddress;
                    dbEntry.UserPhone = item.UserPhone;
                    dbEntry.UserRole = item.UserRole;
                    dbEntry.UserWeb = item.UserWeb;

                }
            }
            Context.SaveChangesAsync();
        }

        public async Task SaveWithId(TUser user)
        {
            if (user.UserId != Guid.Empty)
            {
                Context.TUser.Add(user);
                await Context.SaveChangesAsync();
            }
        }
    }
}

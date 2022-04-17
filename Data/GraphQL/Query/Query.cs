using Data.Context;
using Data.Entities;
using HotChocolate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Query
{
    public class Query
    {

        public IQueryable<User> GetAllUsers([Service] AppDbContext context)
        {
            return context.Users;
        }

        public IQueryable<User> GetUserByUId([Service] AppDbContext context, string uid)
        {
            var user =  context.Users.SingleOrDefault(x => x.UId == uid);
            return context.Users;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TMS.Data;

namespace TMS.Server.Controllers
{
    public class Service<T> where T : class
    {
        private MyContext context;
        private DbSet<T> set;

        public Service()
        {
            context = new MyContext();
            set = context.Set<T>();
        }

        public IEnumerable<T> GetAll()
        {
            return set;
        }

        public T Get(int id)
        {
            return set.Find(id);
        }

        public void Add(T model)
        {
            set.Add(model);
            context.SaveChanges();
        }

        public void Update(T model)
        {
            context.Entry<T>(model).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            set.Remove(set.Find(id));
            context.SaveChanges();
        }
    }
}
﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TMS.Data;
using AutoMapper;
using TMS.ViewModels;
using System.Threading.Tasks;

namespace TMS.Server.Services
{
    public class Service<T, Tview> where T : class where Tview : IViewBase
    {
        protected MyContext context;
        protected DbSet<T> set;

        public Service()
        {
            context = new MyContext();
            set = context.Set<T>();
        }

        #region Govno

        public Tview AddNEW(Tview model)
        {
            var entity = Mapper.Map<Tview, T>(model);
            Mapping.cx.Set<T>().Add(entity);
            Mapping.cx.SaveChanges();
            var i = Mapper.Map<T, Tview>(entity);
            return i;
        }



        #endregion

        public IEnumerable<T> GetAll()
        {
            return set;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await set.ToListAsync();
        }

        public T Get(int id)
        {
            return set.Find(id);
        }

        public void Delete(int id)
        {
            set.Remove(set.Find(id));
            context.SaveChanges();
        }

        public void Add(Tview model)
        {
            var entity = Mapper.Map<Tview, T>(model);
            Mapping.cx.Set<T>().Add(entity);
            Mapping.cx.SaveChanges();
        }

        public void Update(Tview viewModel)
        {
            var entity = Mapper.Map<Tview, T>(viewModel);
            var model = Mapping.cx.Set<T>().Find(viewModel.GetId());

            foreach(var property in typeof(T).GetProperties())
            {
                property.SetValue(model, property.GetValue(entity));
            }
            Mapping.cx.SaveChanges();
        }
    }
}
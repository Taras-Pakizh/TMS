using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using TMS.Data;
using TMS.ViewModels;
using AutoMapper;
using TMS.Server.Services;
using System.Threading.Tasks;
using Task = TMS.Data.Task;

namespace TMS.Server.Controllers
{
    public class TasksController : ApiController
    {
        private Service<Task, TaskView> service;

        public TasksController() : base()
        {
            service = new Service<Task, TaskView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public async Task<IEnumerable<TaskView>> Get()
        {
            return Mapper.Map<IEnumerable<Task>, IEnumerable<TaskView>>(await service.GetAllAsync());
            //return await System.Threading.Tasks.Task.Run(() =>
            //{
            //    return new List<TaskView>()
            //    {
            //        new TaskView()
            //        {
            //            effort = 100
            //        }
            //    };
            //});
        }

        // GET api/Report/5
        public TaskView Get(int id)
        {
            return Mapper.Map<Task, TaskView>(service.Get(id));
        }

        //--------------------------Govno ----------------------------------
        // POST api/Report
        public TaskView Post([FromBody]TaskView model)
        {
            TaskView i;
            if (!ModelState.IsValid) { return null; }

            try
            {
                i = service.AddNEW(model);
                return i;
            }

            catch (Exception e) { return null; }
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]TaskView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Update(model); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
        }

        // DELETE api/Report/5
        public IHttpActionResult Delete(int id)
        {
            try { service.Delete(id); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
        }
    }
}

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
        public IEnumerable<TaskView> Get()
        {
            return Mapper.Map<IEnumerable<Task>, IEnumerable<TaskView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public TaskView Get(int id)
        {
            return Mapper.Map<Task, TaskView>(service.Get(id));
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]TaskView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
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

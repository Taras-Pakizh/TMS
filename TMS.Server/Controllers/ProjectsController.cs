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
    public class ProjectsController : ApiController
    {
        private Service<Project, ProjectView> service;

        public ProjectsController() : base()
        {
            service = new Service<Project, ProjectView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public IEnumerable<ProjectView> Get()
        {
            return Mapper.Map<IEnumerable<Project>, IEnumerable<ProjectView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public ProjectView Get(int id)
        {
            return Mapper.Map<Project, ProjectView>(service.Get(id));
        }

        //------------------GOVNO-------------------
        // POST api/Report
        public ProjectView Post([FromBody]ProjectView model)
        {
            ProjectView i;
            if (!ModelState.IsValid) { return null; }

            try
            {
                i = service.AddNEW(model);
                return i;
            }

            catch (Exception e) { return null; }
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]ProjectView model)
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

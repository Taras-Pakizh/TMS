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
    public class TeamsController : ApiController
    {
        private Service<Team, TeamView> service;

        public TeamsController() : base()
        {
            service = new Service<Team, TeamView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public IEnumerable<TeamView> Get()
        {
            return Mapper.Map<IEnumerable<Team>, IEnumerable<TeamView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public TeamView Get(int id)
        {
            return Mapper.Map<Team, TeamView>(service.Get(id));
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]TeamView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]TeamView model)
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

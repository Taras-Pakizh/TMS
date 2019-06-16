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
    public class RisksController : ApiController
    {
        private Service<Risk, RiskView> service;

        public RisksController() : base()
        {
            service = new Service<Risk, RiskView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public IEnumerable<RiskView> Get()
        {
            return Mapper.Map<IEnumerable<Risk>, IEnumerable<RiskView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public RiskView Get(int id)
        {
            return Mapper.Map<Risk, RiskView>(service.Get(id));
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]RiskView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]RiskView model)
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

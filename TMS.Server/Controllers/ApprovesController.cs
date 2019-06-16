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
    public class ApprovesController : ApiController
    {
        private Service<Approve, ApproveView> service;

        public ApprovesController() : base()
        {
            service = new Service<Approve, ApproveView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public IEnumerable<ApproveView> Get()
        {
            return Mapper.Map<IEnumerable<Approve>, IEnumerable<ApproveView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public ApproveView Get(int id)
        {
            return Mapper.Map<Approve, ApproveView>(service.Get(id));
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]ApproveView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }

            return Ok();
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]ApproveView model)
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

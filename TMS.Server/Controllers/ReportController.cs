using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using TMS.Data;

namespace TMS.Server.Controllers
{
    //[Authorize(Roles = "Engineer")]
    public class ReportController : ApiController
    {
        private MyContext context;
        private Service<Report> service;

        public ReportController() : base()
        {
            context = new MyContext();
            service = new Service<Report>();
        }

        // GET api/Report
        public IEnumerable<Report> Get()
        {
            return service.GetAll();
        }

        // GET api/Report/5
        public Report Get(int id)
        {
            return service.Get(id);
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]Report model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }
            
            return Ok();
        }

        // PUT api/Report/5
        public IHttpActionResult Put(int id, [FromBody]Report model)
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

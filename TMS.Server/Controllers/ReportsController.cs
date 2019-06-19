using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

using TMS.Data;
using TMS.ViewModels;
using AutoMapper;
using TMS.Server.Services;
using Task = System.Threading.Tasks.Task;

namespace TMS.Server.Controllers
{
    //[Authorize(Roles = "Engineer")]
    public class ReportsController : ApiController
    {
        private Service<Report, ReportView> service;
        
        public ReportsController() : base()
        {
            service = new Service<Report, ReportView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public async Task<IEnumerable<ReportView>> Get()
        {
            //return await System.Threading.Tasks.Task.Run(() =>
            //{
            //    return new List<ReportView>()
            //    {
            //        new ReportView()
            //        {
            //            effort = 100
            //        }
            //    };
            //});
            return Mapper.Map<IEnumerable<Report>, IEnumerable<ReportView>>(await service.GetAllAsync());
        }

        // GET api/Report/5
        public ReportView Get(int id)
        {
            return Mapper.Map<Report, ReportView>(service.Get(id));
        }

        // POST api/Report
        public IHttpActionResult Post([FromBody]ReportView model)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try { service.Add(model); }

            catch (Exception e) { BadRequest(e.Message); }
            
            return Ok();
        }

        // PUT api/Report
        public IHttpActionResult Put([FromBody]ReportView model)
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

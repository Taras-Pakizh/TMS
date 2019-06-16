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
    public class UsersController : ApiController
    {
        private Service<User, UserView> service;

        public UsersController() : base()
        {
            service = new Service<User, UserView>();
            Mapping.Initialize();
        }

        // GET api/Report
        public IEnumerable<UserView> Get()
        {
            return Mapper.Map<IEnumerable<User>, IEnumerable<UserView>>(service.GetAll().ToList());
        }

        // GET api/Report/5
        public UserView Get(int id)
        {
            return Mapper.Map<User, UserView>(service.Get(id));
        }
    }
}

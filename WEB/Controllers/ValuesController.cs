using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WEB.Controllers
{
    [RoutePrefix("api/values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        public dynamic Get()
        {
            return new { id = 1, name = "SomeName" };
        }


        // GET api/values/5
        [Authorize, HttpGet, Route("one"),]
        public string GetOne()
        {
            return "value";
        }

        [HttpGet, Route("foradm"), Authorize(Roles = "admin")]
        public string GetAdm()
        {
            return "value for admin";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

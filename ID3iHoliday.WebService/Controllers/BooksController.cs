using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ID3iHoliday.WebService.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        // GET: api/Books
        [Route("")]
        public IHttpActionResult Get()
        {
            return Ok(new string[] { "value1", "value2" });
        }

        // GET: api/Books/5
        [Route("{id:int}")]
        public IHttpActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST: api/Books
        [Route("")]
        [HttpPost]
        public IHttpActionResult Post([FromBody]string value)
        {
            return Ok("post");
        }

        // PUT: api/Books/5
        [Route("{id:int}")]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return Ok("put");
        }

        // DELETE: api/Books/5
        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok("delete");
        }
    }
}

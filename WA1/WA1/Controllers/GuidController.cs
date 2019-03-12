using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using WA.Service.Interfaces;
using WA.Service.Models;
using WA.Service.Results;
using WA1.Attributes;

namespace WA1.Controllers
{
    [LogExceptionFilter]
    public class GuidController : ApiController
    {
        public IUserCredService UserCredService { get; set; }
        // GET: api/Guid
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Guid/5
        /// <summary>
        /// get user data controller
        /// </summary>
        /// <param name="id">guid id to search</param>
        /// <returns></returns>
        public async Task<GuidResult> Get(Guid id)
        {
            var result = await UserCredService.ReadGuid(id.ToString());
            return result;
        }

        // POST: api/Guid/
        /// <summary>
        /// create user data controller method
        /// </summary>
        /// <param name="model">model data</param>
        /// <param name="id">optional parameter</param>
        /// <returns></returns>
        public async Task<IHttpActionResult> Post([FromBody]CredentialModel model, string id = null)
        {
            if(model != null)
            {
                model.UserId = !string.IsNullOrEmpty(id) ? id : string.Empty;
                var result = await UserCredService.CreateGuid(model);
                return Ok(result);
            }
            return BadRequest("data malformed");
        }

        // PUT: api/Guid/5
        /// <summary>
        /// update user data controller method
        /// </summary>
        /// <param name="id"> guid to use</param>
        /// <param name="model">model with data</param>
        /// <returns></returns>
        public async Task<GuidResult> Put(Guid id, [FromBody]CredentialModel model)
        {
            model.UserId = id.ToString();
            var result = await UserCredService.Update(model);
            return result;
        }

        // DELETE: api/Guid/5
        /// <summary>
        /// delete user data controller method
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task Delete(Guid id)
        {
            await UserCredService.DeleteGuid(id.ToString());
        }
    }
}

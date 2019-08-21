using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using TotalSynergy.Service;
using TotalSynergy.UI.BO;

namespace TotalSynergy.WebAPI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [RoutePrefix("api/Contact")]
    public class ContactController : ApiController
    {
        private readonly IContactService Service;

        public ContactController(IContactService service)
        {
            Service = service;
        }

        // GET api/Contact/All
        [HttpGet, Route("All")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<ContactVM> data = await Service.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region DB
        // POST api/Contact/Create
        [HttpPost, Route("Create")]
        public async Task<IHttpActionResult> CreateContact([FromBody]ContactVM dto)
        {
            try
            {
                bool result = await Service.Create(dto);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }


        #endregion

    }
}

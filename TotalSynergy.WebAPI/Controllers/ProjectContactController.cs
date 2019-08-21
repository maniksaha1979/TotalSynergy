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
    [RoutePrefix("api/ProjectContact")]
    public class ProjectContactController : ApiController
    {
        private readonly IProjectContactService Service;

        public ProjectContactController(IProjectContactService service)
        {
            this.Service = service;
        }

        // GET api/ProjectContact/All
        [HttpGet, Route("All")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<ProjectContactVM> data = await Service.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region DB
        // POST api/ProjectContact/Create
        [HttpPost, Route("Create")]
        public async Task<IHttpActionResult> CreateProject([FromBody]ProjectContactVM dto)
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

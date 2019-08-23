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
using System.Web.Http.Cors;


namespace TotalSynergy.WebAPI.Controllers
{
    [EnableCors(origins: "http://localhost:55836", headers: "*", methods: "*")]
    [ApiExplorerSettings(IgnoreApi = true)]
    [RoutePrefix("api/Project")]
    public class ProjectController : ApiController
    {
        private readonly IProjectService Service;

        public ProjectController(IProjectService service)
        {
            this.Service = service;
        }

        // GET api/Project/All
        [HttpGet, Route("All")]
        public async Task<IHttpActionResult> GetAllAsync()
        {
            try
            {
                IEnumerable<ProjectVM> data = await Service.GetAll();
                return Ok(data);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        #region DB
        // POST api/Project/Create
        [HttpPost, Route("Create")]
        public async Task<IHttpActionResult> CreateProject([FromBody]ProjectVM dto)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Common;
using Common.Requests;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("api/survey")]
    [ApiController]
    public class SurveyController : ControllerBase
    {
        private readonly ISurveyService surveyService;
        public SurveyController(ISurveyService surveyService)
        {
            this.surveyService = surveyService;
        }

        [HttpPost]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Post([FromBody] SurveyRequest request)
        {
            if (surveyService.Create(request))
            {
                return Ok(new RestResponse(true, "Create survey successfully"));
            }
            return Ok(new RestResponse(false, "Create survey failed"));
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult Put(long id, [FromBody] SurveyRequest request)
        {
            request.Id = id;
            if (surveyService.Update(request))
            {
                return Ok(new RestResponse(true, "Update survey successfully"));
            }
            return Ok(new RestResponse(false, "Update survey failed"));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] string orderBy,
                                 [FromQuery] string order,
                                 [FromQuery] string keyword,
                                 [FromQuery] int? status,
                                 [FromQuery] long? doneBy,
                                 [FromQuery] DateTime? startDate = null,
                                 [FromQuery] DateTime? endDate = null)
        {
            var param = new SurveyParam()
            {
                StartDate = startDate,
                EndDate = endDate,
                Keyword = keyword,
                OrderBy = orderBy,
                Order = order,
                Status = status,
                DoneBy = doneBy,
            };
            return Ok(new RestResponse(true, null, surveyService.List(param)));
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(long id)
        {
            return Ok(new RestResponse(true, null, surveyService.One(id)));
        }

        [HttpPost]
        [Route("do")]
        [Authorize]
        public IActionResult DoSurvey([FromBody] DoSurveyRequest request)
        {
            var rs = surveyService.DoSurvey(request);
            if (rs != null)
            {
                return Ok(new RestResponse(true, "Do survey successfully", rs));
            }
            return Ok(new RestResponse(false, "Do survey failed"));
        }
    }
}

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
        public IActionResult Post(SurveyRequest request)
        {
            if (surveyService.Create(request))
            {
                return Ok(new RestResponse(true, "Create survey successfully"));
            }
            return Ok(new RestResponse(false, "Create survey failed"));
        }
    }
}

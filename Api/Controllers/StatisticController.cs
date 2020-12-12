using Common;
using Common.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Route("api/statistic")]
    [ApiController]
    public class StatisticController : ControllerBase
    {
        private IStatisticService statisticService;

        public StatisticController(IStatisticService statisticService)
        {
            this.statisticService = statisticService;
        }

        [HttpGet]
        [Route("survey-user-count")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult SurveyUserCount()
        {
            return Ok(new RestResponse(true, null, statisticService.SurveyUserCountStat()));
        }

        [HttpGet]
        [Route("dashboard")]
        [Authorize(Policy = Policies.Admin)]
        public IActionResult SumStat()
        {
            return Ok(new RestResponse(true, null, statisticService.SumStat()));
        }
    }
}

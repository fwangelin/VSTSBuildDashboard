using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using VSTSBuildDashboard.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using VSTSBuildDashboard.APIModels;
using VSTSBuildDashboard.Controllers;

namespace VSTSBuildDashboard.Controllers
{
    [Route("api/build")]
    [ApiController]
    public class BuildController : Controller
    {
        private readonly VstsClient vstsClient;
        private readonly VisualStudioTeamServicesSettings _settings;

        public BuildController(VstsClient client, IOptions<VisualStudioTeamServicesSettings> settings)
        {

            vstsClient = client ?? throw new ArgumentNullException(nameof(client)); ;
            _settings = settings.Value ?? throw new ArgumentNullException(nameof(settings.Value));
        }

        [HttpGet]
        public async Task<ActionResult<string>> GetBuildDetails([FromQuery] int? buildId)
        {

            // TODO: Create a build where we get Xamarin build from correct build branch. 

            if (buildId == null)
            {
                return BadRequest($"Query Parameter {nameof(buildId)} cannot be null");
            }
      
            var build = await vstsClient.BuildDetails(buildId.Value);

            return Ok(new { name = build.Definition.Name,
                id = build.Id,
                buildNumber = build.BuildNumber,
                queTime = build.QueueTime,
                startTime = build.StartTime,
                finishTime = build.FinishTime != null ? build.FinishTime : null,
                buildTime = build.FinishTime - build.StartTime,
                isFinished = build.FinishTime.HasValue,
                result = build.Result,
                developer = build.RequestedFor.DisplayName,
                developerImage = build.RequestedFor.ImageUrl
          
               });
                            
        }

        [HttpGet, Route("average")]
        public async Task<ActionResult<string>> GetAverageDuration([FromQuery] int? definitionId)
        {
           
            return Ok(new { duration = await vstsClient.GetBuildAverageDuration(definitionId.Value)});
        }

        //TODO: Add information for progress bar. 
        [HttpGet, Route("runningbuild")]
        public async Task<ActionResult<string>> GetRunningBuilds()
        {

            var runningBuild = await vstsClient.GetRunningBuilds();

            return Ok(runningBuild);

        }
    }
}
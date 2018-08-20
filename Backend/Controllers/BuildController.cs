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
        public async Task<ActionResult<string>> GetLatestBuild()
        {

            var build = await vstsClient.BuildDetails(367);

            return Ok(build);

        }

        [HttpGet]
        public async Task<ActionResult<string>> GetRunningBuilds()
        {

            var build = await vstsClient.GetRunningBuilds();

            return Ok(build);

        }
    }
}
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using VSTSBuildDashboard.VstsModels;
using VSTSBuildDashboard.Extensions;
using VSTSBuildDashboard.VstsModels;
using VSTSBuildDashboard.APIModels;

namespace VSTSBuildDashboard.Services
{
 public class VstsClient
        {
            private readonly Uri _buildApiUri;
            private readonly HttpClient _client;
            private readonly Uri _apiUri;

            public VstsClient(HttpClient client)
            {
                _apiUri = new Uri(client.BaseAddress, "_apis/");
                _buildApiUri = new Uri(_apiUri, "build/builds/");
                _client = client;
            }

            public Task<BuildDetailsApiModel> BuildDetails(int buildNumber)
            {
            var uri = new Uri(_buildApiUri,
                $"{buildNumber}?api-version=4.1");
                return _client.DeserializeJsonGetRequest<BuildDetailsApiModel>(uri);
            }

            public async Task<ListReleasesApiModel.ReleaseListItem> GetReleaseItem(Guid projectId, int buildDefintionId,
                int buildId)
            {
                var listReleasesApiModel = await _client.DeserializeJsonGetRequest<ListReleasesApiModel>(
                    new Uri(
                        $"https://offerta.vsrm.visualstudio.com/offerta/_apis/release/releases?sourceId={projectId}:{buildDefintionId}&artifactVersionId={buildId}&api-version=4.1-preview.6"
                    )
                );

                if (listReleasesApiModel.Count != 1)
                    throw new ArgumentException("Only one result should be requested.");
                return listReleasesApiModel.Items[0];
            }

            public Task<GitCommitDetailsModel> GetCommitDetails(BuildDetailsApiModel model) =>
                _client.DeserializeJsonGetRequest<GitCommitDetailsModel>(new Uri(model.Links.SourceVersionDisplayUri
                    .Href));

            public Task<GitCommitChangesModel> GetCommitChanges(GitCommitDetailsModel model) =>
                _client.DeserializeJsonGetRequest<GitCommitChangesModel>(new Uri(model.Links.Changes.Href));

            public async Task<BuildListModel.VstsValue[]>  GetRunningBuilds()
            {
                return (await _client.DeserializeJsonGetRequest<BuildListModel>(new Uri(_buildApiUri, "builds?statusFilter=inProgress&api-version=4.1"))).Value;
            }

        public async Task<TimeSpan> GetBuildAverageDuration(int definitionId)
        {
            var uri = new Uri(_buildApiUri, $"?definitions={definitionId}&resultFilter=succeeded&api-version=4.1");
            var builds = (await _client.DeserializeJsonGetRequest<BuildListModel>(uri)).Value;

            var averageTicks = builds.Select(x => x.FinishTime - x.StartTime).Average(x => x.Ticks);
            long longAverageTicks = Convert.ToInt64(averageTicks);


            return new TimeSpan(longAverageTicks);
        }
    }
}
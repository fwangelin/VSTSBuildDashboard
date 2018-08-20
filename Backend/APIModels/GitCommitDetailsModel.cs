using System;
using Newtonsoft.Json;

namespace VSTSBuildDashboard.VstsModels
{
    public class GitCommitDetailsModel
    {
        [JsonProperty("treeId")] public string TreeId { get; set; }

        [JsonProperty("commitId")] public string CommitId { get; set; }

        [JsonProperty("author")] public CommitAuthor Author { get; set; }

        [JsonProperty("committer")] public CommitAuthor Committer { get; set; }

        [JsonProperty("comment")] public string Comment { get; set; }

        [JsonProperty("parents")] public string[] Parents { get; set; }

        [JsonProperty("url")] public string Url { get; set; }

        [JsonProperty("remoteUrl")] public string RemoteUrl { get; set; }

        [JsonProperty("_links")] public GitCommitDetailsModelLinks Links { get; set; }

        [JsonProperty("push")] public PushedyBy Push { get; set; }


        public class CommitAuthor
        {
            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("email")] public string Email { get; set; }

            [JsonProperty("date")] public DateTimeOffset Date { get; set; }

            [JsonProperty("imageUrl")] public string ImageUrl { get; set; }
        }

        public class GitCommitDetailsModelLinks
        {
            [JsonProperty("self")] public Changes Self { get; set; }

            [JsonProperty("repository")] public Changes Repository { get; set; }

            [JsonProperty("web")] public Changes Web { get; set; }

            [JsonProperty("changes")] public Changes Changes { get; set; }
        }

        public class Changes
        {
            [JsonProperty("href")] public string Href { get; set; }
        }

        public class PushedyBy
        {
            [JsonProperty("pushedBy")] public PushedBy PushedBy { get; set; }

            [JsonProperty("pushId")] public long PushId { get; set; }

            [JsonProperty("date")] public DateTimeOffset Date { get; set; }
        }

        public class PushedBy
        {
            [JsonProperty("displayName")] public string DisplayName { get; set; }

            [JsonProperty("url")] public string Url { get; set; }

            [JsonProperty("_links")] public PushedByLinks Links { get; set; }

            [JsonProperty("id")] public Guid Id { get; set; }

            [JsonProperty("uniqueName")] public string UniqueName { get; set; }

            [JsonProperty("imageUrl")] public string ImageUrl { get; set; }

            [JsonProperty("descriptor")] public string Descriptor { get; set; }
        }

        public class PushedByLinks
        {
            [JsonProperty("avatar")] public Changes Avatar { get; set; }
        }
    }
}
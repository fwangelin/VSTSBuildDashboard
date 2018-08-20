using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace VSTSBuildDashboard.VstsModels
{
    public class ListReleasesApiModel
    {
        [JsonProperty("count")] public long Count { get; set; }

        [JsonProperty("value")] public IList<ReleaseListItem> Items { get; set; }

        public class ReleaseListItem
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("status")] public string Status { get; set; }

            [JsonProperty("createdOn")] public DateTimeOffset CreatedOn { get; set; }

            [JsonProperty("modifiedOn")] public DateTimeOffset ModifiedOn { get; set; }

            [JsonProperty("modifiedBy")] public EdBy ModifiedBy { get; set; }

            [JsonProperty("createdBy")] public EdBy CreatedBy { get; set; }

            [JsonProperty("variables")] public Properties Variables { get; set; }

            [JsonProperty("variableGroups")] public IList<object> VariableGroups { get; set; }

            [JsonProperty("releaseDefinition")] public ReleaseDefinition ReleaseDefinition { get; set; }

            [JsonProperty("description")] public string Description { get; set; }

            [JsonProperty("reason")] public string Reason { get; set; }

            [JsonProperty("releaseNameFormat")] public string ReleaseNameFormat { get; set; }

            [JsonProperty("keepForever")] public bool KeepForever { get; set; }

            [JsonProperty("definitionSnapshotRevision")]
            public long DefinitionSnapshotRevision { get; set; }

            [JsonProperty("logsContainerUrl")] public string LogsContainerUrl { get; set; }

            [JsonProperty("url")] public string Url { get; set; }

            [JsonProperty("_links")] public ValueLinks Links { get; set; }

            [JsonProperty("tags")] public IList<object> Tags { get; set; }

            [JsonProperty("triggeringArtifactAlias")]
            public object TriggeringArtifactAlias { get; set; }

            [JsonProperty("projectReference")] public ProjectReference ProjectReference { get; set; }

            [JsonProperty("properties")] public Properties Properties { get; set; }
        }

        public class EdBy
        {
            [JsonProperty("displayName")] public string DisplayName { get; set; }

            [JsonProperty("url")] public string Url { get; set; }

            [JsonProperty("_links")] public CreatedByLinks Links { get; set; }

            [JsonProperty("id")] public Guid Id { get; set; }

            [JsonProperty("uniqueName")] public string UniqueName { get; set; }

            [JsonProperty("imageUrl")] public string ImageUrl { get; set; }

            [JsonProperty("descriptor")] public string Descriptor { get; set; }
        }

        public class CreatedByLinks
        {
            [JsonProperty("avatar")] public Self Avatar { get; set; }
        }

        public class Self
        {
            [JsonProperty("href")] public string Href { get; set; }
        }

        public class ValueLinks
        {
            [JsonProperty("self")] public Self Self { get; set; }

            [JsonProperty("web")] public Self Web { get; set; }
        }

        public class ProjectReference
        {
            [JsonProperty("id")] public Guid Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }
        }

        public class Properties
        {
        }

        public class ReleaseDefinition
        {
            [JsonProperty("id")] public long Id { get; set; }

            [JsonProperty("name")] public string Name { get; set; }

            [JsonProperty("path")] public string Path { get; set; }

            [JsonProperty("projectReference")] public object ProjectReference { get; set; }

            [JsonProperty("url")] public string Url { get; set; }

            [JsonProperty("_links")] public ValueLinks Links { get; set; }
        }
    }
}
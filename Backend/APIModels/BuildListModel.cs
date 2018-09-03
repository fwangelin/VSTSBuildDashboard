using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace VSTSBuildDashboard.APIModels
{
    public class BuildListModel
    {
        [JsonProperty("count")] public long Count { get; set; }
        [JsonProperty("value")] public VstsValue[] Value { get; set; }
        public class VstsValue
        {
            [JsonProperty("_links")] public ValueLinks Links { get; set; }
            [JsonProperty("properties")] public Properties Properties { get; set; }
            [JsonProperty("tags")] public object[] Tags { get; set; }
            [JsonProperty("validationResults")] public object[] ValidationResults { get; set; }
            [JsonProperty("plans")] public Plan[] Plans { get; set; }
            [JsonProperty("triggerInfo")] public Properties TriggerInfo { get; set; }
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("buildNumber")] public string BuildNumber { get; set; }
            [JsonProperty("status")] public string Status { get; set; }
            [JsonProperty("result")] public string Result { get; set; }
            [JsonProperty("queueTime")] public DateTimeOffset QueueTime { get; set; }
            [JsonProperty("startTime")] public DateTimeOffset StartTime { get; set; }
            [JsonProperty("finishTime")] public DateTimeOffset FinishTime { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
            [JsonProperty("definition")] public Definition Definition { get; set; }
            [JsonProperty("buildNumberRevision")] public long BuildNumberRevision { get; set; }
            [JsonProperty("project")] public Project Project { get; set; }
            [JsonProperty("uri")] public string Uri { get; set; }
            [JsonProperty("sourceBranch")] public string SourceBranch { get; set; }
            [JsonProperty("sourceVersion")] public string SourceVersion { get; set; }
            [JsonProperty("queue")] public Queue Queue { get; set; }
            [JsonProperty("priority")] public string Priority { get; set; }
            [JsonProperty("reason")] public string Reason { get; set; }
            [JsonProperty("requestedFor")] public LastChangedBy RequestedFor { get; set; }
            [JsonProperty("requestedBy")] public LastChangedBy RequestedBy { get; set; }
            [JsonProperty("lastChangedDate")] public DateTimeOffset LastChangedDate { get; set; }
            [JsonProperty("lastChangedBy")] public LastChangedBy LastChangedBy { get; set; }
            [JsonProperty("orchestrationPlan")] public Plan OrchestrationPlan { get; set; }
            [JsonProperty("logs")] public Logs Logs { get; set; }
            [JsonProperty("repository")] public Repository Repository { get; set; }
            [JsonProperty("keepForever")] public bool KeepForever { get; set; }
            [JsonProperty("retainedByRelease")] public bool RetainedByRelease { get; set; }
            [JsonProperty("triggeredByBuild")] public object TriggeredByBuild { get; set; }
        }
        public class Definition
        {
            [JsonProperty("drafts")] public object[] Drafts { get; set; }
            [JsonProperty("id")] public int Id { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
            [JsonProperty("uri")] public string Uri { get; set; }
            [JsonProperty("path")] public string Path { get; set; }
            [JsonProperty("type")] public string Type { get; set; }
            [JsonProperty("queueStatus")] public string QueueStatus { get; set; }
            [JsonProperty("revision")] public long Revision { get; set; }
            [JsonProperty("project")] public Project Project { get; set; }
        }
        public class Project
        {
            [JsonProperty("id")] public Guid Id { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
            [JsonProperty("state")] public string State { get; set; }
            [JsonProperty("revision")] public long Revision { get; set; }
            [JsonProperty("visibility")] public string Visibility { get; set; }
        }
        public class LastChangedBy
        {
            [JsonProperty("displayName")] public string DisplayName { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
            [JsonProperty("_links")] public LastChangedByLinks Links { get; set; }
            [JsonProperty("id")] public Guid Id { get; set; }
            [JsonProperty("uniqueName")] public string UniqueName { get; set; }
            [JsonProperty("imageUrl")] public string ImageUrl { get; set; }
            [JsonProperty("descriptor")] public string Descriptor { get; set; }
        }
        public class LastChangedByLinks
        {
            [JsonProperty("avatar")] public Badge Avatar { get; set; }
        }
        public class Badge
        {
            [JsonProperty("href")] public string Href { get; set; }
        }
        public class ValueLinks
        {
            [JsonProperty("self")] public Badge Self { get; set; }
            [JsonProperty("web")] public Badge Web { get; set; }
            [JsonProperty("sourceVersionDisplayUri")]
            public Badge SourceVersionDisplayUri { get; set; }
            [JsonProperty("timeline")] public Badge Timeline { get; set; }
            [JsonProperty("badge")] public Badge Badge { get; set; }
        }
        public class Logs
        {
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("type")] public string Type { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
        }
        public class Plan
        {
            [JsonProperty("planId")] public Guid PlanId { get; set; }
        }
        public class Properties
        {
        }
        public class Queue
        {
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("pool")] public Pool Pool { get; set; }
        }
        public class Pool
        {
            [JsonProperty("id")] public long Id { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("isHosted")] public bool IsHosted { get; set; }
        }
        public class Repository
        {
            [JsonProperty("id")] public Guid Id { get; set; }
            [JsonProperty("type")] public string Type { get; set; }
            [JsonProperty("name")] public string Name { get; set; }
            [JsonProperty("url")] public string Url { get; set; }
            [JsonProperty("clean")] public object Clean { get; set; }
            [JsonProperty("checkoutSubmodules")] public bool CheckoutSubmodules { get; set; }
        }
    }
}

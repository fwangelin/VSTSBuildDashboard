using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VSTSBuildDashboard.VstsModels
{
    public class Self
    {
        public string Href { get; set; }
    }

    public class Web
    {
        public string Href { get; set; }
    }

    public class SourceVersionDisplayUri
    {
        public string Href { get; set; }
    }

    public class Timeline
    {
        public string Href { get; set; }
    }

    public class Badge
    {
        public string Href { get; set; }
    }

    public class Links
    {
        public Self Self { get; set; }
        public Web Web { get; set; }
        public SourceVersionDisplayUri SourceVersionDisplayUri { get; set; }
        public Timeline Timeline { get; set; }
        public Badge Badge { get; set; }
    }

    public class Properties
    {
    }

    public class Plan
    {
        public string PlanId { get; set; }
    }

    public class TriggerInfo
    {
    }

    public class Project
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
        public string Visibility { get; set; }
    }

    public class Definition
    {
        public IReadOnlyList<object> Drafts { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Uri { get; set; }
        public string Path { get; set; }
        public string Type { get; set; }
        public string QueueStatus { get; set; }
        public int Revision { get; set; }
        public Project Project { get; set; }
    }

    public class Project2
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string State { get; set; }
        public int Revision { get; set; }
        public string Visibility { get; set; }
    }

    public class Pool
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsHosted { get; set; }
    }

    public class Queue
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public Pool Pool { get; set; }
    }

    public class Avatar
    {
        public string Href { get; set; }
    }

    public class Links2
    {
        public Avatar Avatar { get; set; }
    }

    public class RequestedFor
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        [JsonProperty("_links")] public Links2 Links { get; set; }
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
        public string Descriptor { get; set; }
    }

    public class Avatar2
    {
        public string Href { get; set; }
    }

    public class Links3
    {
        public Avatar2 Avatar { get; set; }
    }

    public class RequestedBy
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public Links3 Links { get; set; }
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
        public string Descriptor { get; set; }
    }

    public class Avatar3
    {
        public string Href { get; set; }
    }

    public class Links4
    {
        public Avatar3 Avatar { get; set; }
    }

    public class LastChangedBy
    {
        public string DisplayName { get; set; }
        public string Url { get; set; }
        public Links4 Links { get; set; }
        public string Id { get; set; }
        public string UniqueName { get; set; }
        public string ImageUrl { get; set; }
        public string Descriptor { get; set; }
    }

    public class OrchestrationPlan
    {
        public string PlanId { get; set; }
    }

    public class Logs
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Repository
    {
        public string Id { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public object Clean { get; set; }
        public bool CheckoutSubmodules { get; set; }
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuildStatus
    {
        [EnumMember] All,
        [EnumMember] Cancelling,
        [EnumMember] Completed,
        [EnumMember] InProgress,
        [EnumMember] None,
        [EnumMember] NotStarted,
        [EnumMember] Postponed
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuildResult
    {
        [EnumMember] Canceled,
        [EnumMember] Failed,
        [EnumMember] None,
        [EnumMember] PartiallySucceeded,
        [EnumMember] Succeeded
    }

    [JsonConverter(typeof(StringEnumConverter))]
    public enum BuildReason
    {
        [EnumMember] All,
        [EnumMember] BatchedCi,
        [EnumMember] BuildCompletion,
        [EnumMember] CheckInShelveset,
        [EnumMember] IndividualCi,
        [EnumMember] Manual,
        [EnumMember] None,
        [EnumMember] PullRequest,
        [EnumMember] Schedule,
        [EnumMember] Triggered,
        [EnumMember] UserCreated,
        [EnumMember] ValidateShelveset
    }

    public class BuildDetailsApiModel
    {
        [JsonProperty("_links")] public Links Links { get; set; }
        public Properties Properties { get; set; }
        public IReadOnlyList<object> Tags { get; set; }
        public IReadOnlyList<object> ValidationResults { get; set; }
        public IReadOnlyList<Plan> Plans { get; set; }
        public TriggerInfo TriggerInfo { get; set; }
        public int Id { get; set; }
        public string BuildNumber { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BuildStatus Status { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BuildResult? Result { get; set; }

        public DateTime QueueTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public string Url { get; set; }
        public Definition Definition { get; set; }
        public int BuildNumberRevision { get; set; }
        public Project2 Project { get; set; }
        public string Uri { get; set; }
        public string SourceBranch { get; set; }
        public string SourceVersion { get; set; }
        public Queue Queue { get; set; }
        public string Priority { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public BuildReason Reason { get; set; }

        public RequestedFor RequestedFor { get; set; }
        public RequestedBy RequestedBy { get; set; }
        public DateTime LastChangedDate { get; set; }
        public LastChangedBy LastChangedBy { get; set; }
        public string Parameters { get; set; }
        public OrchestrationPlan OrchestrationPlan { get; set; }
        public Logs Logs { get; set; }
        public Repository Repository { get; set; }
        public bool KeepForever { get; set; }
        public bool RetainedByRelease { get; set; }
        public object TriggeredByBuild { get; set; }
    }
}
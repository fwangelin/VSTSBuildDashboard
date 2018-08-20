using System;
using System.Collections.Generic;

namespace VSTSBuildDashboard.VstsModels
{
    public class Log
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string Url { get; set; }
    }

    public class Task
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Version { get; set; }
    }

    public class Record
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? FinishTime { get; set; }
        public object CurrentOperation { get; set; }
        public object PercentComplete { get; set; }
        public string State { get; set; }
        public string Result { get; set; }
        public object ResultCode { get; set; }
        public int ChangeId { get; set; }
        public DateTime LastModified { get; set; }
        public string WorkerName { get; set; }
        public object Order { get; set; }
        public object Details { get; set; }
        public int ErrorCount { get; set; }
        public int WarningCount { get; set; }
        public object Url { get; set; }
        public Log Log { get; set; }
        public Task Task { get; set; }
    }

    public class TimeLineDetailsApiModel
    {
        public List<Record> Records { get; set; }
        public string LastChangedBy { get; set; }
        public DateTime LastChangedOn { get; set; }
        public string Id { get; set; }
        public int ChangeId { get; set; }
        public string Url { get; set; }
    }
}

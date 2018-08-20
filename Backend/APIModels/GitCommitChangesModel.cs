using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace VSTSBuildDashboard.VstsModels
{
    public class GitCommitChangesModel
    {
        [JsonProperty("changeCounts")] public VstsChangeCounts ChangeCounts { get; set; }

        [JsonProperty("changes")] public Change[] Changes { get; set; }


        public class VstsChangeCounts
        {
            [JsonProperty("Edit")] public long Edit { get; set; }
        }

        public class Change
        {
            [JsonProperty("item")] public Item Item { get; set; }

            [JsonProperty("changeType")] public VstsChangeType ChangeType { get; set; }


            [JsonConverter(typeof(StringEnumConverter))]
            public enum VstsChangeType
            {
                Add,
                All,
                Branch,
                Delete,
                Edit,
                Encoding,
                Lock,
                Merge,
                None,
                Property,
                Rename,
                Rollback,
                SourceRename,
                TargetRename,
                Undelete
            }
        }

        public class Item
        {
            [JsonConverter(typeof(StringEnumConverter))]
            public enum VstsGitObjectType
            {
                Blob,
                Tree
            }

            [JsonProperty("objectId")] public string ObjectId { get; set; }

            [JsonProperty("originalObjectId")] public string OriginalObjectId { get; set; }

            [JsonProperty("gitObjectType")] public VstsGitObjectType GitObjectType { get; set; }

            [JsonProperty("commitId")] public string CommitId { get; set; }

            [JsonProperty("path")] public string Path { get; set; }

            [JsonProperty("isFolder", NullValueHandling = NullValueHandling.Ignore)]
            public bool? IsFolder { get; set; }

            [JsonProperty("url")] public string Url { get; set; }
        }
    }
}
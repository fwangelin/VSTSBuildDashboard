using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VSTSBuildDashboard.APIModels
{
    public class Descriptor
    {
        public string IdentityType { get; set; }
        public string Identifier { get; set; }
    }

    public class Properties
    {
        public string SchemaClassName { get; set; }
        public string Description { get; set; }
        public string Domain { get; set; }
        public string Account { get; set; }
        public string DN { get; set; }
        public string Mail { get; set; }
        public string SpecialType { get; set; }
        public string PUID { get; set; }
        public DateTime ComplianceValidated { get; set; }
        public DateTime MetadataUpdateDate { get; set; }
    }

    public class GetMemberModel
    {
        public string Id { get; set; }
        public Descriptor Descriptor { get; set; }
        public string ProviderDisplayName { get; set; }
        public object CustomDisplayName { get; set; }
        public string DisplayName { get; set; }
        public bool IsActive { get; set; }
        public int UniqueUserId { get; set; }
        public bool IsContainer { get; set; }
        public List<object> Members { get; set; }
        public List<object> MemberOf { get; set; }
        public Properties Properties { get; set; }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
    public class SubscriptionResponse : BaseResponse
    {
        [JsonProperty("cloudname")]
        public string Cloudname { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("subscription")]
        public string Subscription { get; set; }
        [JsonProperty("subscriptionRenewalPeriod")]
        public string SubscriptionRenewalPeriod { get; set; }
        [JsonProperty("subscriptionStartDate")]
        public DateTime SubscriptionStartDate { get; set; }
        [JsonProperty("creditUsageIn30Days")]
        public CreditUsage CreditUsageIn30Days { get; set; }
        [JsonProperty("cdnUsage")]
        public CDNUsageData CDNUsage { get; set; }
        [JsonProperty("transformationUsage")]
        public TransformationData TransformationUsage { get; set; }
        [JsonProperty("storageUsage")]
        public StorageUsageData StorageUsage { get; set; }

        public class CDNUsageData
        {
            [JsonProperty("usageInGB")]
            public double UsageInGB { get; set; }
            [JsonProperty("limitInGB")]
            public double LimitInGB { get; set; }
        }

        public class TransformationData
        {
            [JsonProperty("count")]
            public long Count { get; set; }
        }

        public class CreditUsage
        {
            [JsonProperty("limit")]
            public long Limit { get; set; }
            [JsonProperty("usage")]
            public double Usage { get; set; }
        }

        public class StorageUsageData
        {
            [JsonProperty("usageInGB")]
            public double UsageInGB { get; set; }
            [JsonProperty("limitInGB")]
            public double LimitInGB { get; set; }
            [JsonProperty("assetCount")]
            public int AssetCount { get; set; }
        }
    }
}

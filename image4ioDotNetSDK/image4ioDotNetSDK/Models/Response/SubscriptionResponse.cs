using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image4ioDotNetSDK.Models
{
    public class SubscriptionResponse : BaseResponse
    {
        public string Cloudname { get; set; }
        public string Status { get; set; }
        public string Subscription { get; set; }
        public string SubscriptionRenewalPeriod { get; set; }
        public DateTime SubscriptionStartDate { get; set; }
        public DateTime SubscriptionEndDate { get; set; }
        public CreditUsage CreditUsageIn30Days { get; set; }
        public CreditUsage CreditUsageInSubscriptionPeriod { get; set; }
        public CDNUsageData CDNUsage { get; set; }
        public TransformationData TransformationUsage { get; set; }
        public StorageUsageData StorageUsage { get; set; }

        public class CDNUsageData
        {
            public long UsageInByte { get; set; }
            public double UsageInGB { get; set; }
        }

        public class TransformationData
        {
            public long Count { get; set; }
        }

        public class CreditUsage
        {
            public long Limit { get; set; }
            public double Usage { get; set; }
            public double UsagePercentage { get; set; }
        }

        public class StorageUsageData
        {
            public long UsageInByte { get; set; }
            public double UsageInMB { get; set; }
            public int AssetCount { get; set; }
        }
    }
}
